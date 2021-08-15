namespace Resistance.Postgres
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static System.DateTimeOffset;

    public record BulkImporterBatchResult<TEntity>
    {
        public BulkImporterBatchResult(int batchId, List<TEntity> entities, long startTime, long stopTime) {
            BatchId   = batchId;
            Entities  = entities.AsReadOnly();
            StartTime = FromUnixTimeMilliseconds(startTime);
            StopTime  = FromUnixTimeMilliseconds(stopTime);
            Elapsed   = MicroProfiler.GetElapsed(startTime, stopTime);
        }

        public int                    BatchId   { get; }
        public IReadOnlyList<TEntity> Entities  { get; }
        public DateTimeOffset         StartTime { get; }
        public DateTimeOffset         StopTime  { get; }
        public TimeSpan               Elapsed   { get; }
    }

    public record BulkImporterResult<TEntity>
    {
        public BulkImporterResult(Guid id, List<BulkImporterBatchResult<TEntity>> results, long startTime, long stopTime) {
            Id            = id;
            Results       = results.AsReadOnly();
            StartTime     = FromUnixTimeMilliseconds(startTime);
            StopTime      = FromUnixTimeMilliseconds(stopTime);
            Elapsed       = MicroProfiler.GetElapsed(startTime, stopTime);
            BatchesCount  = results.Count;
            EntitiesCount = results.Sum(x => (long)x.Entities.Count);
        }

        public Guid                                            Id            { get; }
        public IReadOnlyList<BulkImporterBatchResult<TEntity>> Results       { get; }
        public DateTimeOffset                                  StartTime     { get; }
        public DateTimeOffset                                  StopTime      { get; }
        public TimeSpan                                        Elapsed       { get; }
        public int                                             BatchesCount  { get; }
        public long                                            EntitiesCount { get; }
    }
}