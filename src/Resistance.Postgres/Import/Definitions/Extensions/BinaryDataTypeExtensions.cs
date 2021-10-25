namespace Resistance.Postgres;

using System;
using NpgsqlTypes;

public static class BinaryDataTypeExtensions
{
    public static TableDefinitionBuilder<TEntity> Bytes<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, byte[]> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Bytea);
}