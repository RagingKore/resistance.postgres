namespace Resistance.Postgres
{
    using System;
    using NpgsqlTypes;

    public static class CharacterTypeExtensions
    {
        public static TableDefinitionBuilder<TEntity> Varchar<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, string> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Varchar);

        public static TableDefinitionBuilder<TEntity> Character<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, string> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Char);

        public static TableDefinitionBuilder<TEntity> Text<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, string> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Text);
    }
}