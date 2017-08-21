// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisposableBase.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common
{
    using System;

    public abstract class DisposableBase : IDisposable
    {
        ~DisposableBase()
        {
            Dispose(false);
        }

        protected bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposeManagedResources)
        {
            IsDisposed = true;
        }
    }
}