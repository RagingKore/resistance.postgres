namespace Resistance.Postgres
{
    using System.Collections.Generic;
    using System.Linq;
    using static System.String;

    public record TableDefinition<TEntity>
    {
        const string CopyCommandTemplate = "COPY {0}({1}) FROM STDIN BINARY;";

        public TableDefinition(string schema, string tableName, List<ColumnDefinition<TEntity>> columns, bool quotingEnabled = false) {
            Schema                    = schema;
            TableName                 = tableName;
            Columns                   = columns.AsReadOnly();
            QuotingEnabled            = quotingEnabled;
            FullyQualifiedTableName   = NpgsqlUtils.GetFullyQualifiedTableName(schema, tableName, quotingEnabled);
            FullyQualifiedColumnNames = Join(", ", columns.Select(x => x.ColumnName.GetIdentifier(quotingEnabled)));
            CopyCommand               = Format(CopyCommandTemplate, FullyQualifiedTableName, FullyQualifiedColumnNames);
        }

        public static TableDefinitionBuilder<TEntity> Builder => new();

        public string                                   Schema                    { get; }
        public string                                   TableName                 { get; }
        public IReadOnlyList<ColumnDefinition<TEntity>> Columns                   { get; }
        public bool                                     QuotingEnabled            { get; }
        public string                                   FullyQualifiedTableName   { get; }
        public string                                   FullyQualifiedColumnNames { get; }
        public string                                   CopyCommand               { get; }

        public static TableDefinitionBuilder<TEntity> For(string tableName) => new(tableName);

        public override string ToString() => $"TableDefinition (Table = {FullyQualifiedTableName})";
    }
}