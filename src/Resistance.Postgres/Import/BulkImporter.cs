namespace Resistance.Postgres;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Humanizer;
using JetBrains.Annotations;
using Metrics;
using Npgsql;
using Open.ChannelExtensions;
using Polly;
using Serilog;
using static Serilog.Log;
using static System.Threading.SynchronizationContextScope;

public class BulkImporter
{
    internal static readonly UnboundedChannelOptions DefaultUnboundedChannelOptions = new();
    internal static readonly int                     DefaultMaxConcurrency          = Environment.ProcessorCount;
    internal static readonly int                     DefaultMaxBatchSize            = 1000;
}

[PublicAPI]
public class BulkImporter<TEntity> : BulkImporter
{
    static readonly ILogger Log = ForContext("SourceContext", $"Resistance.Postgres.BulkImporter<{typeof(TEntity).Name}>");

    public BulkImporter(TableDefinition<TEntity> tableDefinition, Func<NpgsqlConnection> getConnection, AsyncPolicy? policy = null) {
        Table         = tableDefinition;
        GetConnection = getConnection;
        Policy        = policy ?? PostgresErrorHandlingPolicies.WaitAndRetry();
    }

    TableDefinition<TEntity> Table         { get; }
    Func<NpgsqlConnection>   GetConnection { get; }
    AsyncPolicy              Policy        { get; }

    public ValueTask<BulkImporterResult<TEntity>> Import(ChannelReader<TEntity> reader, int maxConcurrency, int maxBatchSize, Guid correlationId, CancellationToken cancellationToken = default) {
        if (cancellationToken.IsCancellationRequested)
            return ValueTask.FromCanceled<BulkImporterResult<TEntity>>(cancellationToken);

        using (DisabledSyncContext())
            return ImportEntities();

        async ValueTask<BulkImporterResult<TEntity>> ImportEntities() {
            var startTime  = MicroProfiler.GetTimestamp();
            var batchCount = 0;

            try {
                Log.Verbose("({CorrelationId}) importing...", correlationId);

                var results = await reader.Batch(maxBatchSize)
                    .PipeAsync(maxConcurrency, batch => ImportBatch(batch, ++batchCount, correlationId, Table, GetConnection, Policy, cancellationToken), maxConcurrency * 2, true, cancellationToken)
                    .ReadAllAsync(cancellationToken)
                    .ToListAsync(cancellationToken);

                var result = new BulkImporterResult<TEntity>(correlationId, results, startTime, MicroProfiler.GetTimestamp());

                BulkImporterMetrics.TrackSuccessfulImport(Table.FullyQualifiedTableName, correlationId, result.EntitiesCount, startTime);

                Log.Information("({CorrelationId}) {EntitiesCount} entities imported using {BatchesCount} batches in {Elapsed}", correlationId, result.EntitiesCount, result.BatchesCount, MicroProfiler.GetElapsed(startTime).Humanize(3));

                return result;
            }
            catch (Exception ex) {
                BulkImporterMetrics.TrackFailedImport(Table.FullyQualifiedTableName, correlationId, startTime);

                throw new BulkImporterException(correlationId, Table.FullyQualifiedTableName, ex);
            }
        }
    }

    static async ValueTask<BulkImporterBatchResult<TEntity>> ImportBatch(
        List<TEntity> batch, int batchId, Guid correlationId, TableDefinition<TEntity> table,
        Func<NpgsqlConnection> getConnection, IAsyncPolicy policy, CancellationToken cancellationToken
    ) {
        var batchSize = batch.Count;
        var startTime = MicroProfiler.GetTimestamp();

        Log.Debug("({CorrelationId}) importing batch {BatchId} with {BatchSize} entities...", correlationId, batchId, batchSize);

        try {
            await policy.ExecuteAsync(
                async (context, token) => {
                    await using var connection = getConnection();

                    _ = await connection.BulkImport(batch, table, token);

                    BulkImporterMetrics.TrackImportedBatch(table.FullyQualifiedTableName, correlationId, batchId, batchSize, startTime);
                },
                new(batchId.ToString()),
                cancellationToken
            );
        }
        catch (Exception ex) {
            BulkImporterMetrics.TrackFailedBatch(table.FullyQualifiedTableName, correlationId, batchId, batchSize, startTime);

            throw new BatchImportException(correlationId, batchId, ex);
        }

        var result = new BulkImporterBatchResult<TEntity>(batchId, batch, startTime, MicroProfiler.GetTimestamp());

        Log.Debug("({CorrelationId}) imported batch {BatchId} with {BatchSize} entities in {Elapsed}", correlationId, batchId, batchSize, result.Elapsed.Humanize(3));

        return result;
    }
}