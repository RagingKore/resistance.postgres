namespace Resistance.Postgres
{
    using System.Collections.Generic;
    using static Npgsql.PostgresErrorCodes;

    public static class PostgresTransientErrors
    {
        public static IEnumerable<string> All
            => new[] {
                InsufficientResources,
                DiskFull,
                OutOfMemory,
                TooManyConnections,
                ConfigurationLimitExceeded,
                LockNotAvailable,
                OperatorIntervention,
                QueryCanceled,
                AdminShutdown,
                CrashShutdown,
                CannotConnectNow,
                LockNotAvailable,
                SystemError,
                IoError,
                ObjectInUse,
                ObjectNotInPrerequisiteState,
                ConnectionException,
                ConnectionDoesNotExist,
                ConnectionFailure,
                SqlClientUnableToEstablishSqlConnection,
                SqlServerRejectedEstablishmentOfSqlConnection,
                TransactionResolutionUnknown,
                SerializationFailure
            };
    }
}