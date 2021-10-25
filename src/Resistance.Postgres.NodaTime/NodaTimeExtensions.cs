namespace Resistance.Postgres.NodaTime;

using System;
using global::NodaTime;
using NpgsqlTypes;

public static class NodaTimeExtensions
{
    public static TableDefinitionBuilder<TEntity> TimeStampTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, ZonedDateTime> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.TimestampTz);

    public static TableDefinitionBuilder<TEntity> TimeStampTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, ZonedDateTime?> getNullableValue)
        => table.Column(columnName, getNullableValue, NpgsqlDbType.TimestampTz);

    public static TableDefinitionBuilder<TEntity> TimeStampTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, OffsetDateTime> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.TimestampTz);

    public static TableDefinitionBuilder<TEntity> TimeStampTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, OffsetDateTime?> getNullableValue)
        => table.Column(columnName, getNullableValue, NpgsqlDbType.TimestampTz);

    public static TableDefinitionBuilder<TEntity> TimeStamp<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, Instant> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.Timestamp);

    public static TableDefinitionBuilder<TEntity> TimeStamp<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, Instant?> getNullableValue)
        => table.Column(columnName, getNullableValue, NpgsqlDbType.Timestamp);

    public static TableDefinitionBuilder<TEntity> TimeStamp<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, LocalDateTime> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.Timestamp);

    public static TableDefinitionBuilder<TEntity> TimeStamp<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, LocalDateTime?> getNullableValue)
        => table.Column(columnName, getNullableValue, NpgsqlDbType.Timestamp);

    public static TableDefinitionBuilder<TEntity> Date<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, LocalDate> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.Date);

    public static TableDefinitionBuilder<TEntity> Date<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, LocalDate?> getNullableValue)
        => table.Column(columnName, getNullableValue, NpgsqlDbType.Date);

    public static TableDefinitionBuilder<TEntity> Date<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, NpgsqlDate> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.Date);

    public static TableDefinitionBuilder<TEntity> Date<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, NpgsqlDate?> getNullableValue)
        => table.Column(columnName, getNullableValue, NpgsqlDbType.Date);

    public static TableDefinitionBuilder<TEntity> Time<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, LocalTime> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.Time);

    public static TableDefinitionBuilder<TEntity> Time<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, LocalTime?> getNullableValue)
        => table.Column(columnName, getNullableValue, NpgsqlDbType.Time);

    public static TableDefinitionBuilder<TEntity> TimeTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, OffsetTime> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.TimeTz);

    public static TableDefinitionBuilder<TEntity> TimeTz<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, OffsetTime?> getNullableValue)
        => table.Column(columnName, getNullableValue, NpgsqlDbType.TimeTz);

    public static TableDefinitionBuilder<TEntity> Interval<TEntity>(this TableDefinitionBuilder<TEntity> table, string columnName, Func<TEntity, Period> getValue)
        => table.Column(columnName, getValue, NpgsqlDbType.Interval);
}