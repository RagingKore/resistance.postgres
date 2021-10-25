namespace Resistance.Postgres;

using System;
using NpgsqlTypes;

public static class DateTimeTypeExtensions
{
    public static TableDefinitionBuilder<TEntity> Date<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTime> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Date);

    public static TableDefinitionBuilder<TEntity> Date<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTime?> getNullableValue) => table.Column(columnName, getNullableValue, NpgsqlDbType.Date);

    public static TableDefinitionBuilder<TEntity> Time<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, TimeSpan> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Time);

    public static TableDefinitionBuilder<TEntity> Time<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, TimeSpan?> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Time);

    public static TableDefinitionBuilder<TEntity> TimeStamp<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTime> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Timestamp);

    public static TableDefinitionBuilder<TEntity> TimeStamp<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTime?> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Timestamp);

    public static TableDefinitionBuilder<TEntity> TimeStampTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTime> getValue) => table.Column(columnName, getValue, NpgsqlDbType.TimestampTz);

    public static TableDefinitionBuilder<TEntity> TimeStampTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTime?> getValue) => table.Column(columnName, getValue, NpgsqlDbType.TimestampTz);

    public static TableDefinitionBuilder<TEntity> TimeStampTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTimeOffset> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.TimestampTz);

    public static TableDefinitionBuilder<TEntity> TimeStampTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTimeOffset?> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.TimestampTz);

    public static TableDefinitionBuilder<TEntity> Interval<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, TimeSpan> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Interval);

    public static TableDefinitionBuilder<TEntity> Interval<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, TimeSpan?> getValue) => table.Column(columnName, getValue, NpgsqlDbType.Interval);

    public static TableDefinitionBuilder<TEntity> TimeTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTimeOffset> getValue) => table.Column(columnName, getValue, NpgsqlDbType.TimeTz);

    public static TableDefinitionBuilder<TEntity> TimeTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTimeOffset?> getValue) => table.Column(columnName, getValue, NpgsqlDbType.TimeTz);

    public static TableDefinitionBuilder<TEntity> TimeTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTime> getValue) => table.Column(columnName, getValue, NpgsqlDbType.TimeTz);

    public static TableDefinitionBuilder<TEntity> TimeTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, DateTime?> getValue) => table.Column(columnName, getValue, NpgsqlDbType.TimeTz);

    public static TableDefinitionBuilder<TEntity> TimeTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, TimeSpan> getValue) => table.Column(columnName, getValue, NpgsqlDbType.TimeTz);

    public static TableDefinitionBuilder<TEntity> TimeTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, TimeSpan?> getValue) => table.Column(columnName, getValue, NpgsqlDbType.TimeTz);
}