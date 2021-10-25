namespace Resistance.Postgres;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Npgsql;
using NpgsqlTypes;
using static System.String;

[PublicAPI]
public sealed class TableDefinitionBuilder<TEntity>
{
    public TableDefinitionBuilder() { }

    public TableDefinitionBuilder(string tableName) => Table(tableName);

    string TableSchema    { get; set; } = Empty;
    string TableName      { get; set; } = Empty;
    bool   QuotingEnabled { get; set; }

    List<ColumnDefinition<TEntity>> Columns { get; } = new();

    public TableDefinitionBuilder<TEntity> Schema(string schema) {
        TableSchema = schema;

        return this;
    }

    public TableDefinitionBuilder<TEntity> Table(string table) {
        if (IsNullOrWhiteSpace(table))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(table));

        TableName = table;

        return this;
    }

    public TableDefinitionBuilder<TEntity> EnableQuoting(bool enabled = true) {
        QuotingEnabled = enabled;

        return this;
    }

    public TableDefinitionBuilder<TEntity> Column<TProperty>(string columnName, Func<TEntity, TProperty> getPropertyValue, NpgsqlDbType? dbType = null) {
        Columns.Add(new(columnName, dbType, null, typeof(TProperty), (importer, entity, token) => WriteValue(importer, entity, columnName, getPropertyValue, dbType, token)));

        return this;

        static async Task WriteValue(NpgsqlBinaryImporter importer, TEntity entity, string columnName, Func<TEntity, TProperty> getPropertyValue, NpgsqlDbType? dbType, CancellationToken cancellationToken) {
            var value = GetValue(entity);

            try {
                if (dbType is not null)
                    await importer.WriteAsync(value, dbType.Value, cancellationToken);
                else
                    await importer.WriteAsync(value, cancellationToken);
            }
            catch (Exception ex) {
                throw new($"Failed to write {typeof(TProperty)} value for column {columnName} {dbType}: {value}", ex);
            }

            TProperty GetValue(TEntity entity) {
                try {
                    return getPropertyValue(entity);
                }
                catch (Exception ex) {
                    throw new($"Failed to read {typeof(TProperty)} value for column {columnName} {dbType}", ex);
                }
            }
        }
    }

    public TableDefinitionBuilder<TEntity> Column<TProperty>(string columnName, Func<TEntity, TProperty?> getPropertyNullableValue, NpgsqlDbType? dbType = null) where TProperty : struct {
        Columns.Add(new(columnName, dbType, null, typeof(TProperty), (importer, entity, token) => WriteValue(importer, entity, columnName, getPropertyNullableValue, dbType, token)));

        return this;

        static async Task WriteValue(NpgsqlBinaryImporter importer, TEntity entity, string columnName, Func<TEntity, TProperty?> getPropertyNullableValue, NpgsqlDbType? dbType, CancellationToken cancellationToken) {
            var nullable = GetNullableValue(entity);

            try {
                if (nullable is null)
                    await importer.WriteNullAsync(cancellationToken);
                else if (dbType is not null)
                    await importer.WriteAsync(nullable.Value, dbType.Value, cancellationToken);
                else
                    await importer.WriteAsync(nullable.Value, cancellationToken);
            }
            catch (Exception ex) {
                throw new($"Failed to write {Nullable.GetUnderlyingType(typeof(TProperty))} nullable value for column {columnName} {dbType}: {nullable}", ex);
            }

            TProperty? GetNullableValue(TEntity entity) {
                try {
                    return getPropertyNullableValue(entity);
                }
                catch (Exception ex) {
                    throw new($"Failed to read {Nullable.GetUnderlyingType(typeof(TProperty))} nullable value for column {columnName} {dbType}", ex);
                }
            }
        }
    }

    public TableDefinition<TEntity> Create() => new(TableSchema, TableName, Columns, QuotingEnabled);
}