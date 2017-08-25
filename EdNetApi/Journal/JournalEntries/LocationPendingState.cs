// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationPendingState.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System.ComponentModel;
    using Newtonsoft.Json;

    public class LocationPendingState
    {
        internal LocationPendingState()
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