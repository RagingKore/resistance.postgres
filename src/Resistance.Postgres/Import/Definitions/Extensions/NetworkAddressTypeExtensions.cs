namespace Resistance.Postgres;

using System;
using System.Net;
using System.Net.NetworkInformation;
using NpgsqlTypes;

public static class NetworkAddressTypeExtensions
{
    public static TableDefinitionBuilder<TEntity> InetAddress<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, IPAddress> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Inet);

    public static TableDefinitionBuilder<TEntity> MacAddress<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, PhysicalAddress> getValue) => table.Column(columnName, getValue, NpgsqlDbType.MacAddr);
}