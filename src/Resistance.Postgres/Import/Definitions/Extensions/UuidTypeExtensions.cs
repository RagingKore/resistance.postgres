namespace Resistance.Postgres;

using System;
using NpgsqlTypes;

public static class UuidTypeExtensions
{
    public static TableDefinitionBuilder<TEntity> Uuid<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, Guid> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Uuid);

    public static TableDefinitionBuilder<TEntity> Uuid<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, Guid?> getNullableValue) => table.Column(columnName, getNullableValue, NpgsqlDbType.Uuid);
}