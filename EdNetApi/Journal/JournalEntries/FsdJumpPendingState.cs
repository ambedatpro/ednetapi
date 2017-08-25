// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FsdJumpPendingState.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System.ComponentModel;
    using Newtonsoft.Json;

    public class FsdJumpPendingState
    {
        internal FsdJumpPendingState()
        {
        }

        [JsonProperty("State")]
        [Description("")]
        public string State { get; internal set; }

        [JsonProperty("Trend")]
        [Description("")]
        public int Trend { get; internal set; }
    }
}