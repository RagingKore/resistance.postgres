namespace Resistance.Postgres
{
    public static class StringExtensions
    {
        public static string GetIdentifier(this string identifier, bool usePostgresQuotes) => usePostgresQuotes ? NpgsqlUtils.QuoteIdentifier(identifier) : identifier;
    }
}