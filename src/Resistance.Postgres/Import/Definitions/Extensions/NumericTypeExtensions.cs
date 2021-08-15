namespace Resistance.Postgres
{
    using System;
    using NpgsqlTypes;

    public static class NumericTypeExtensions
    {
        public static TableDefinitionBuilder<TEntity> SmallInt<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, short> getProperty) => table.Column(columnName, getProperty, NpgsqlDbType.Smallint);

        public static TableDefinitionBuilder<TEntity> SmallInt<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, short?> getNullableValue)
            => table.Column(columnName, getNullableValue, NpgsqlDbType.Smallint);

        public static TableDefinitionBuilder<TEntity> Integer<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, int> getProperty) => table.Column(columnName, getProperty, NpgsqlDbType.Integer);

        public static TableDefinitionBuilder<TEntity> Integer<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, int?> getNullableValue) => table.Column(columnName, getNullableValue, NpgsqlDbType.Integer);

        public static TableDefinitionBuilder<TEntity> BigInt<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, long> getProperty) => table.Column(columnName, getProperty, NpgsqlDbType.Bigint);

        public static TableDefinitionBuilder<TEntity> BigInt<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, long?> getNullableValue) => table.Column(columnName, getNullableValue, NpgsqlDbType.Bigint);

        public static TableDefinitionBuilder<TEntity> Numeric<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, decimal> getProperty) => table.Column(columnName, getProperty, NpgsqlDbType.Numeric);

        public static TableDefinitionBuilder<TEntity> Numeric<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, decimal?> getNullableValue)
            => table.Column(columnName, getNullableValue, NpgsqlDbType.Numeric);

        public static TableDefinitionBuilder<TEntity> Real<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, float> getProperty) => table.Column(columnName, getProperty, NpgsqlDbType.Real);

        public static TableDefinitionBuilder<TEntity> Real<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, float?> getNullableValue) => table.Column(columnName, getNullableValue, NpgsqlDbType.Real);

        public static TableDefinitionBuilder<TEntity> Double<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, double> getProperty) => table.Column(columnName, getProperty, NpgsqlDbType.Double);

        public static TableDefinitionBuilder<TEntity> Double<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, double?> getNullableValue)
            => table.Column(columnName, getNullableValue, NpgsqlDbType.Double);
    }
}