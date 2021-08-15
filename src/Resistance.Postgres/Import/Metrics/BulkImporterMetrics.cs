using static System.DateTimeOffset;
using static Ubiquitous.Metrics.Metrics;

namespace Resistance.Postgres.Metrics
{
    using System;
    using Ubiquitous.Metrics;

    static class BulkImporterMetrics
    {
        static ICountMetric SuccessfulImportsCount { get; } = Instance.CreateCount("preem_postgres_imports_successful", "", "table", "correlation_id", "row_count");

        static IHistogramMetric SuccessfulImportsDuration { get; } = Instance.CreateHistogram("preem_postgres_imports_successful_duration", "", "table", "correlation_id", "row_count");

        static ICountMetric FailedImportsCount { get; } = Instance.CreateCount("preem_postgres_imports_failed", "", "table", "correlation_id");

        static IHistogramMetric FailedImportsDuration { get; } = Instance.CreateHistogram("preem_postgres_imports_failed_duration", "", "table", "correlation_id");

        static ICountMetric SuccessfulBatchesCount { get; } = Instance.CreateCount("preem_postgres_imports_batches_successful", "", "table", "correlation_id", "batch_id", "batch_size");

        static IHistogramMetric SuccessfulBatchesDuration { get; } = Instance.CreateHistogram("preem_postgres_imports_batches_successful_duration", "", "table", "correlation_id", "batch_id", "batch_size");

        static ICountMetric FailedBatchesCount { get; } = Instance.CreateCount("preem_postgres_imports_batches_failed", "", "table", "correlation_id", "batch_id", "batch_size");

        static IHistogramMetric FailedBatchesDuration { get; } = Instance.CreateHistogram("preem_postgres_imports_batches_failed_duration", "", "table", "correlation_id", "batch_id", "batch_size");

        public static void TrackSuccessfulImport(string table, Guid correlationId, long rowCount, long startTime) {
            var labels = new[] {
                table,
                correlationId.ToString(),
                rowCount.ToString()
            };

            SuccessfulImportsDuration.Observe(FromUnixTimeMilliseconds(startTime), labels);
            SuccessfulImportsCount.Inc(labels);
        }

        public static void TrackFailedImport(string table, Guid correlationId, long startTime) {
            var labels = new[] {
                table,
                correlationId.ToString()
            };

            FailedImportsDuration.Observe(FromUnixTimeMilliseconds(startTime), labels);
            FailedImportsCount.Inc(labels);
        }

        public static void TrackImportedBatch(string table, Guid correlationId, int batchId, int batchSize, long startTime) {
            var labels = new[] {
                table,
                correlationId.ToString(),
                batchId.ToString(),
                batchSize.ToString()
            };

            SuccessfulBatchesDuration.Observe(FromUnixTimeMilliseconds(startTime), labels);
            SuccessfulBatchesCount.Inc(labels);
        }

        public static void TrackFailedBatch(string table, Guid correlationId, int batchId, int batchSize, long startTime) {
            var labels = new[] {
                table,
                correlationId.ToString(),
                batchId.ToString(),
                batchSize.ToString()
            };

            FailedBatchesDuration.Observe(FromUnixTimeMilliseconds(startTime), labels);
            FailedBatchesCount.Inc(labels);
        }
    }
}