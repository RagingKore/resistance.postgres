namespace Resistance.Postgres
{
    using System;
    using NpgsqlTypes;

    public static class JsonTypeExtensions
    {
        public static TableDefinitionBuilder<TEntity> Json<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, string> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Json);

        public static TableDefinitionBuilder<TEntity> Jsonb<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, string> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Jsonb);

        public static TableDefinitionBuilder<TEntity> Jsonb<TEntity, TProperty>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, TProperty> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Jsonb);
    }
}