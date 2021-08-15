namespace Resistance.Postgres
{
    using System;
    using NpgsqlTypes;

    public static class BitStringTypeExtensions
    {
        public static TableDefinitionBuilder<TEntity> Bit<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, bool> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Bit);

        public static TableDefinitionBuilder<TEntity> Bit<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, bool?> getNullableValue) => table.Column(columnName, getNullableValue, NpgsqlDbType.Bit);
    }
}