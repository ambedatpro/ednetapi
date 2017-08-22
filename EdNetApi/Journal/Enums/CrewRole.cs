// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrewRole.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    public enum CrewRole
    {
        UnknownValue = -1,
        Idle = 0,

        [Description("Fire Con")]
        FireCon,

        [Description("Fighter Con")]
        FighterCon
    }
}