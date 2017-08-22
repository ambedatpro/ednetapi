// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DockingDeniedType.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    public enum DockingDeniedType
    {
        UnknownValue = -1,

        [Description("No Space")]
        NoSpace = 0,

        [Description("Too Large")]
        TooLarge,
        Hostile,
        Offences,
        Distance,

        [Description("Active Fighter")]
        ActiveFighter,

        [Description("No Reason")]
        NoReason
    }
}