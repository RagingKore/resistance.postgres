namespace Resistance.Postgres;

using System.Linq;
using Npgsql;

public static class PostgresErrorExtensions
{
    public static bool IsTransient(this PostgresException exception) => PostgresTransientErrors.All.Contains(exception.SqlState);
}