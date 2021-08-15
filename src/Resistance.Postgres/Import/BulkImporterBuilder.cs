// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
//
// namespace Resistance.Postgres
// {
//     using System;
//     using Npgsql;
//     using NpgsqlTypes;
//
//     public sealed class BulkImporterBuilder<TEntity>
//     {
//       Func<NpgsqlConnection>          GetConnection          { get; set; }
//       TableDefinitionBuilder<TEntity> TableDefinitionBuilder { get; set; } = new();
//       TableDefinition<TEntity>?       TableDefinition        { get; set; }
//
//         public BulkImporterBuilder<TEntity> Schema(string schema) {
//             TableDefinitionBuilder.Schema(schema);
//             return this;
//         }
//
//         public BulkImporterBuilder<TEntity> Table(string table) {
//             TableDefinitionBuilder.Table(table);
//             return this;
//         }
//
//         public BulkImporterBuilder<TEntity> Table(string schema, string table) {
//           TableDefinitionBuilder.Schema(schema).Table(table);
//           return this;
//         }
//
//         public BulkImporterBuilder<TEntity> Table(TableDefinition<TEntity> definition)
//         {
//           TableDefinition = definition;
//           return this;
//         }
//
//         public BulkImporterBuilder<TEntity> EnableQuoting(bool enabled = true) {
//             TableDefinitionBuilder.EnableQuoting(enabled);
//             return this;
//         }
//
//         public BulkImporterBuilder<TEntity> Map<TProperty>(string columnName, Func<TEntity, TProperty> getProperty) {
//             TableDefinitionBuilder.Column(columnName, getProperty);
//             return this;
//         }
//
//         public BulkImporterBuilder<TEntity> Map<TProperty>(string columnName, Func<TEntity, TProperty> getProperty, NpgsqlDbType dbType) {
//             TableDefinitionBuilder.Column(columnName, getProperty, dbType);
//             return this;
//         }
//
//         // public BulkImporterBuilder<TEntity> Map<TProperty>(string columnName, Func<TEntity, TProperty> getProperty, string dataTypeName) {
//         //     TableDefinitionBuilder.Map(columnName, getProperty, dataTypeName);
//         //     return this;
//         // }
//         
//         public BulkImporterBuilder<TEntity> MapNullable<TProperty>(string columnName, Func<TEntity, TProperty?> getProperty, NpgsqlDbType dbType) where TProperty : struct {
//             TableDefinitionBuilder.Column(columnName, getProperty, dbType);
//             return this;
//         }
//
//         public BulkImporterBuilder<TEntity> Connection(Func<NpgsqlConnection> getConnection) {
//             GetConnection = getConnection;
//             return this;
//         }
//
//         public BulkImporterBuilder<TEntity> Connection(NpgsqlConnection connection) {
//             GetConnection = () => connection;
//             return this;
//         }
//
//         public BulkImporterBuilder<TEntity> Connection(string connectionString) {
//             GetConnection = () => new NpgsqlConnection(connectionString);
//             return this;
//         }
//
//         public BulkImporter<TEntity> Create()
//           => TableDefinition is not null ? new(TableDefinition, GetConnection) : new(TableDefinitionBuilder.Create(), GetConnection);
//
//         // public ValueTask<ulong> Import(IAsyncEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
//         //   => Create().Import(entities, cancellationToken);
//         //
//         // public ValueTask<ulong> Import(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
//         //   => Create().Import(entities, cancellationToken);
//     }
// }

