// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExplorationRank.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.Enums
{
    using System.ComponentModel;

    public enum ExplorationRank
    {
        UnknownValue = -1,
        Aimless = 0,

        [Description("Mostly Aimless")]
        MostlyAimless = 1,
        Scout = 2,
        Surveyor = 3,
        Explorer = 4,
        Pathfinder = 5,
        Ranger = 6,
        Pioneer = 7,
        Elite = 8
    }
}