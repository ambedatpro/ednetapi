// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommitState.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common.Database
{
    public enum CommitState
    {
        Paused,
        CommittingAfterDelay,
        Completed
    }
}