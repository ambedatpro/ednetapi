// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameStatistics.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information
{
    using System;

    public class GameStatistics
    {
        public int SessionsPlayed { get; internal set; }

        public TimeSpan TotalTimePlayed { get; internal set; }

        public TimeSpan? CurrentSessionPlayed { get; internal set; }
    }
}