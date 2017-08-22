// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseManager.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common.Database
{
    using System;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;

    using ServiceStack.OrmLite;

    internal class DatabaseManager<TConnection> : DisposableBase
        where TConnection : DelayedCommitDatabaseConnection
    {
        private readonly OrmLiteConnectionFactory _factory;

        private TConnection _databaseConnection;

        public DatabaseManager(string databaseFolderPath)
        {
            if (!Directory.Exists(databaseFolderPath))
            {
                Directory.CreateDirectory(databaseFolderPath);
            }

            DatabaseFilePath = Path.Combine(databaseFolderPath, "Journal.sqlite");

            var connectionString = $@"Data Source=""{DatabaseFilePath}"";Version=3;";
            _factory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
        }

        public string DatabaseFilePath { get; }

        public TConnection CreateNonDelayConnection()
        {
            return (TConnection)Activator.CreateInstance(typeof(TConnection), _factory, 0);
        }

        public void ForceCommit()
        {
            _databaseConnection?.ForceCommitAndDispose();
            _databaseConnection = null;
        }

        public TConnection GetOrCreateConnection()
        {
            if (_databaseConnection != null && _databaseConnection.PauseCommit())
            {
                return _databaseConnection;
            }

            _databaseConnection = (TConnection)Activator.CreateInstance(typeof(TConnection), _factory, 5000);
            return _databaseConnection;
        }

        internal static void InsertOrUpdate<T>(
            IDbConnection connection,
            T item,
            Expression<Func<T, bool>> singleItemPredicate,
            Expression<Func<T, object>> updateOnlyFields = null)
        {
            var type = item.GetType();
            var idProperty = type.GetProperty("Id");
            var currentId = (int?)idProperty?.GetValue(item);
            if (currentId != 0)
            {
                throw new ApplicationException("Cannot insert or update with non-zero ID");
            }

            var query = connection.From<T>().Where(singleItemPredicate);
            var existingItem = connection.Select(query).SingleOrDefault();
            if (existingItem == null)
            {
                var rowId = (int)connection.Insert(item, true);
                idProperty.SetValue(item, rowId);
                return;
            }

            var existingId = (int)idProperty.GetValue(existingItem);
            idProperty.SetValue(item, existingId);

            var affectedRowCount = updateOnlyFields == null
                                       ? connection.Update(item, singleItemPredicate)
                                       : connection.UpdateOnly(item, updateOnlyFields, singleItemPredicate);
            if (affectedRowCount != 1)
            {
                throw new ApplicationException("Update failed");
            }
        }

        protected override void Dispose(bool disposeManagedResources)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposeManagedResources)
            {
                _databaseConnection?.RollbackAndDispose();
                _databaseConnection = null;
            }

            base.Dispose(disposeManagedResources);
        }
    }
}