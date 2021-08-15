namespace Resistance.Postgres
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Channels;
    using System.Threading.Tasks;
    using Open.ChannelExtensions;

    public static class BulkImporterExtensions
    {
        public static ValueTask<BulkImporterResult<TEntity>> Import<TEntity>(this BulkImporter<TEntity> source, ChannelReader<TEntity> reader, int maxConcurrency, int maxBatchSize, CancellationToken cancellationToken = default)
            => source.Import(reader, maxConcurrency, maxBatchSize, Guid.NewGuid(), cancellationToken);

        public static ValueTask<BulkImporterResult<TEntity>> Import<TEntity>(this BulkImporter<TEntity> source, ChannelReader<TEntity> reader, Guid correlationId, CancellationToken cancellationToken = default)
            => source.Import(reader, BulkImporter.DefaultMaxConcurrency, BulkImporter.DefaultMaxBatchSize, correlationId, cancellationToken);

        public static ValueTask<BulkImporterResult<TEntity>> Import<TEntity>(this BulkImporter<TEntity> source, ChannelReader<TEntity> reader, CancellationToken cancellationToken = default)
            => source.Import(reader, BulkImporter.DefaultMaxConcurrency, BulkImporter.DefaultMaxBatchSize, Guid.NewGuid(), cancellationToken);

        public static ValueTask<BulkImporterResult<TEntity>> Import<TEntity>(
            this BulkImporter<TEntity> source, IAsyncEnumerable<TEntity> entities, int maxConcurrency, int maxBatchSize, Guid correlationId, CancellationToken cancellationToken = default
        )
            => source.Import(entities.ToChannel(BulkImporter.DefaultUnboundedChannelOptions, true), maxConcurrency, maxBatchSize, correlationId, cancellationToken);

        public static ValueTask<BulkImporterResult<TEntity>> Import<TEntity>(this BulkImporter<TEntity> source, IAsyncEnumerable<TEntity> entities, int maxConcurrency, int maxBatchSize, CancellationToken cancellationToken = default)
            => Import(source, entities, maxConcurrency, maxBatchSize, Guid.NewGuid(), cancellationToken);

        public static ValueTask<BulkImporterResult<TEntity>> Import<TEntity>(this BulkImporter<TEntity> source, IAsyncEnumerable<TEntity> entities, Guid correlationId, CancellationToken cancellationToken = default)
            => Import(source, entities, BulkImporter.DefaultMaxConcurrency, BulkImporter.DefaultMaxBatchSize, correlationId, cancellationToken);

        public static ValueTask<BulkImporterResult<TEntity>> Import<TEntity>(this BulkImporter<TEntity> source, IAsyncEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            => Import(source, entities, BulkImporter.DefaultMaxConcurrency, BulkImporter.DefaultMaxBatchSize, Guid.NewGuid(), cancellationToken);
    }
}