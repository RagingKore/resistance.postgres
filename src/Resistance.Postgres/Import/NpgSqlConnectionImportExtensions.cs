namespace Resistance.Postgres;

using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Npgsql;

public static class NpgSqlConnectionImportExtensions
{
    public static async ValueTask<ulong> BulkImport<TEntity>(this NpgsqlConnection connection, IAsyncEnumerable<TEntity> entities, TableDefinition<TEntity> table, CancellationToken cancellationToken = default) {
        if (connection.State == ConnectionState.Closed)
            await connection.OpenAsync(cancellationToken);

        await using var importer = await connection.BeginBinaryImportAsync(table.CopyCommand, cancellationToken);

        await foreach (var entity in entities.WithCancellation(cancellationToken)) {
            cancellationToken.ThrowIfCancellationRequested();
            await importer.WriteRow<TEntity>(entity, table, cancellationToken);
        }

        return await importer.CompleteAsync(cancellationToken);
    }

    public static async ValueTask<ulong> BulkImport<TEntity>(this NpgsqlConnection connection, List<TEntity> entities, TableDefinition<TEntity> table, CancellationToken cancellationToken = default) {
        if (connection.State == ConnectionState.Closed)
            await connection.OpenAsync(cancellationToken);

        await using var importer = await connection.BeginBinaryImportAsync(table.CopyCommand, cancellationToken);

        foreach (var entity in entities) {
            cancellationToken.ThrowIfCancellationRequested();
            await importer.WriteRow<TEntity>(entity, table, cancellationToken);
        }

        return await importer.CompleteAsync(cancellationToken);
    }

    static async Task WriteRow<TEntity>(this NpgsqlBinaryImporter importer, TEntity entity, TableDefinition<TEntity> table, CancellationToken cancellationToken = default) {
        await importer.StartRowAsync(cancellationToken);
        foreach (var column in table.Columns)
            await column.WriteValue(importer, entity, cancellationToken);
    }
}