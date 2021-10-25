namespace Resistance.Postgres;

using System;
using NpgsqlTypes;

public static class BooleanTypeExtensions
{
    public static TableDefinitionBuilder<TEntity> Boolean<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, bool> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Boolean);

    public static TableDefinitionBuilder<TEntity> Boolean<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, bool?> getNullableValue)
        => table.Column(columnName, getNullableValue, NpgsqlDbType.Boolean);
}