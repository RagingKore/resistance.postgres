namespace Resistance.Postgres
{
    using System;
    
    public class BulkImporterException : Exception
    {
        public BulkImporterException(Guid correlationId, string tableName, Exception inner) : base($"({correlationId}) {tableName} import failed! {inner.Message}", inner) {
            CorrelationId = correlationId;
            TableName     = tableName;
        }

        public Guid   CorrelationId { get; }
        public string TableName     { get; }
    }

    public class BatchImportException : Exception
    {
        public BatchImportException(Guid correlationId, int batchId, Exception inner) : base($"{batchId} batch error >> {inner.Message}", inner) {
            CorrelationId = correlationId;
            BatchId       = batchId;
        }

        public Guid CorrelationId { get; }
        public int  BatchId       { get; }
    }
}