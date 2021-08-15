namespace Resistance.Postgres
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Npgsql;
    using NpgsqlTypes;

    public delegate Task WriteColumnValue<in TEntity>(NpgsqlBinaryImporter importer, TEntity entity, CancellationToken cancellationToken);

    public record ColumnDefinition<TEntity>
    {
        public ColumnDefinition(string columnName, NpgsqlDbType? dbType, string? dataTypeName, Type clrType, WriteColumnValue<TEntity> writeValue) {
            ColumnName   = columnName;
            ClrType      = clrType;
            DbType       = dbType;
            DataTypeName = dataTypeName;
            WriteValue   = writeValue;
        }

        public string                    ColumnName   { get; }
        public Type                      ClrType      { get; }
        public NpgsqlDbType?             DbType       { get; }
        public string?                   DataTypeName { get; }
        public WriteColumnValue<TEntity> WriteValue   { get; }

        public override string ToString() => $"{ColumnName} {DbType} ({ClrType.Name})";
    }
}