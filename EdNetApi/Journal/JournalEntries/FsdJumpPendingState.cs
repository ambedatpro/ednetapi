// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FsdJumpPendingState.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using Newtonsoft.Json;

    public class FsdJumpPendingState
    {
        internal FsdJumpPendingState()
        {
        }

        [JsonProperty("State")]
        public string State { get; internal set; }

        [JsonProperty("Trend")]
        public int Trend { get; internal set; }
    }
}