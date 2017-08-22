// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FsdJumpRecoveringState.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using Newtonsoft.Json;

    public class FsdJumpRecoveringState
    {
        internal FsdJumpRecoveringState()
        {
        }

        [JsonProperty("State")]
        public string State { get; internal set; }

        [JsonProperty("Trend")]
        public int Trend { get; internal set; }
    }
}