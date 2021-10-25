namespace Resistance.Postgres;

using System;
using NpgsqlTypes;

public static class MonetaryTypeExtensions
{
    public static TableDefinitionBuilder<TEntity> Money<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, decimal> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Money);

    public static TableDefinitionBuilder<TEntity> Money<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, decimal?> getNullableValue) => table.Column(columnName, getNullableValue, NpgsqlDbType.Money);
}