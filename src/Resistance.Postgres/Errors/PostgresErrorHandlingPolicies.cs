namespace Resistance.Postgres
{
    using System;
    using Npgsql;
    using Polly;
    using static System.TimeSpan;

    public static class PostgresErrorHandlingPolicies
    {
        static readonly Random Jitterer = new();

        public static AsyncPolicy WaitAndRetry(int retries = 5)
            => Policy.Handle<TimeoutException>().Or<PostgresException>(ex => ex.IsTransient()).WaitAndRetryAsync(retries, x => FromSeconds(Math.Pow(2, x)) + FromMilliseconds(Jitterer.Next(0, 100)));
    }
}