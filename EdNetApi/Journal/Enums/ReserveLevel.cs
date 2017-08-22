// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReserveLevel.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    public enum ReserveLevel
    {
        UnknownValue = -1,
        Pristine = 0,
        Major,
        Common,
        Low,
        Depleted
    }
}