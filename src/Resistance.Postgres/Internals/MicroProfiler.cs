using static System.DateTimeOffset;

namespace Resistance.Postgres;

using System;

static class MicroProfiler
{
    public static long GetTimestamp() => UtcNow.ToUnixTimeMilliseconds();

    public static DateTimeOffset Now() => UtcNow;

    public static long GetElapsedMilliseconds(long start) => GetTimestamp() - start;

    public static long GetElapsedMilliseconds(DateTimeOffset start) => GetTimestamp() - start.ToUnixTimeMilliseconds();

    public static TimeSpan GetElapsed(long start) => FromUnixTimeMilliseconds(GetTimestamp()) - FromUnixTimeMilliseconds(start);

    public static TimeSpan GetElapsed(DateTimeOffset start) => FromUnixTimeMilliseconds(GetTimestamp()) - start;

    public static TimeSpan GetElapsed(long start, long stop) => FromUnixTimeMilliseconds(stop) - FromUnixTimeMilliseconds(start);
}