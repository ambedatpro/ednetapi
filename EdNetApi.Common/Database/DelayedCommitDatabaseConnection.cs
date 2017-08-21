// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DelayedCommitDatabaseConnection.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common.Database
{
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Threading;

    using EdNetApi.Common;

    using ServiceStack.Data;
    using ServiceStack.OrmLite;

    internal abstract class DelayedCommitDatabaseConnection : DisposableBase
    {
        private readonly object _lockObject;
        private readonly int _commitDelay;

        private IDbTransaction _transaction;
        private Timer _commitTimer;
        private DateTime _commitTime;
        private CommitState _commitState;

        protected DelayedCommitDatabaseConnection(IDbConnectionFactory factory, int commitDelay)
        {
            _lockObject = new object();
            _commitDelay = commitDelay;
            _commitTimer = new Timer(CommitAfterDelayCallback);
            _commitState = CommitState.Paused;

            Connection = factory.Open();
            _transaction = Connection.OpenTransaction();
        }

        protected IDbConnection Connection { get; private set; }

        public void DelayedCommitAndDispose()
        {
            lock (_lockObject)
            {
                if (_commitState == CommitState.Completed)
                {
                    return;
                }

                _commitTime = DateTime.UtcNow.AddMilliseconds(_commitDelay);
                _commitTimer.Change(_commitDelay, Timeout.Infinite);
                _commitState = CommitState.CommittingAfterDelay;
            }
        }

        public void ForceCommitAndDispose()
        {
            lock (_lockObject)
            {
                if (_commitState == CommitState.Completed)
                {
                    return;
                }

                _commitTimer?.Dispose();
                _commitTimer = null;

                _commitState = CommitState.Completed;

                CommitAndDisposeTransaction();
                DisposeConnection();

                base.Dispose(true);
            }
        }

        public bool PauseCommit()
        {
            lock (_lockObject)
            {
                switch (_commitState)
                {
                    case CommitState.Paused:
                        return true;
                    case CommitState.CommittingAfterDelay:
                        _commitState = CommitState.Paused;
                        _commitTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        return true;
                    case CommitState.Completed:
                        return false;
                    default:
                        return false;
                }
            }
        }

        public void RollbackAndDispose()
        {
            lock (_lockObject)
            {
                _commitState = CommitState.Completed;

                RollbackAndDisposeTransaction();
                DisposeConnection();

                base.Dispose(true);
            }
        }

        protected override void Dispose(bool disposeManagedResources)
        {
            if (IsDisposed)
            {
                return;
            }

            // Error: DatabaseConnection should be implicitly disposed using 
            // * CommitAndDispose
            // * ForceCommitAndDispose
            // * RollbackAndDispose
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

            RollbackAndDispose();

            base.Dispose(disposeManagedResources);
        }

        private void CommitAfterDelayCallback(object state)
        {
            lock (_lockObject)
            {
                if (_commitState != CommitState.CommittingAfterDelay)
                {
                    return;
                }

                var timeLeftBeforeCommit = (int)(_commitTime - DateTime.UtcNow).TotalMilliseconds;
                if (timeLeftBeforeCommit > 0)
                {
                    _commitTimer.Change(timeLeftBeforeCommit, Timeout.Infinite);
                    return;
                }

                ForceCommitAndDispose();
            }
        }

        private void CommitAndDisposeTransaction()
        {
            if (_transaction == null)
            {
                return;
            }

            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }

        private void DisposeConnection()
        {
            if (Connection == null)
            {
                return;
            }

            Connection.Dispose();
            Connection = null;
        }

        private void RollbackAndDisposeTransaction()
        {
            if (_transaction == null)
            {
                return;
            }

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }
    }
}