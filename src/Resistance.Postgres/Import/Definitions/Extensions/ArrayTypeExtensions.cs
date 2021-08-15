namespace Resistance.Postgres
{
    using System;
    using NpgsqlTypes;

    public static class ArrayTypeExtensions
    {
        public static TableDefinitionBuilder<TEntity> Array<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, byte[][]> getValue) => Array(table, columnName, getValue, NpgsqlDbType.Bytea);

        public static TableDefinitionBuilder<TEntity> Array<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, short[]> getValue) => Array(table, columnName, getValue, NpgsqlDbType.Smallint);

        public static TableDefinitionBuilder<TEntity> Array<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, int[]> getValue) => Array(table, columnName, getValue, NpgsqlDbType.Integer);

        public static TableDefinitionBuilder<TEntity> Array<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, long[]> getValue) => Array(table, columnName, getValue, NpgsqlDbType.Bigint);

        public static TableDefinitionBuilder<TEntity> Array<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, decimal[]> getValue) => Array(table, columnName, getValue, NpgsqlDbType.Numeric);

        public static TableDefinitionBuilder<TEntity> Array<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, float[]> getValue) => Array(table, columnName, getValue, NpgsqlDbType.Real);

        public static TableDefinitionBuilder<TEntity> Array<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, double[]> getValue) => Array(table, columnName, getValue, NpgsqlDbType.Double);

        public static TableDefinitionBuilder<TEntity> Array<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, string[]> getValue) => Array(table, columnName, getValue, NpgsqlDbType.Text);

        public static TableDefinitionBuilder<TEntity> Array<TEntity, TProperty>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, TProperty> getValue, NpgsqlDbType type)
            => table.Column(columnName, getValue, NpgsqlDbType.Array | type);
    }
}