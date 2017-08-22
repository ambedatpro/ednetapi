// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PowerplayState.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    public enum PowerplayState
    {
        UnknownValue = -1,

        [Description("In Prepare Radius")]
        InPrepareRadius = 0,
        Prepared,
        Exploited,
        Contested,
        Controlled,
        Turmoil,

        [Description("Home System")]
        HomeSystem
    }
}