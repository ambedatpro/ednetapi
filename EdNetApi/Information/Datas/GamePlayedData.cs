// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GamePlayedData.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information.Datas
{
    using System;

    public class GamePlayedData
    {
        public int SessionsPlayed { get; internal set; }

        public TimeSpan TotalTimePlayed { get; internal set; }

        public int SessionStartedId { get; internal set; }
    }
}