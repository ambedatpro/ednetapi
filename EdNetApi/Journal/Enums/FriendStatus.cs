// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendStatus.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    public enum FriendStatus
    {
        UnknownValue = -1,
        Requested = 0,
        Declined,
        Added,
        Lost,
        Offline,
        Online
    }
}