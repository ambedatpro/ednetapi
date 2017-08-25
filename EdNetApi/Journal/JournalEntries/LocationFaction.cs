// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationFaction.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System.ComponentModel;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class LocationFaction
    {
        internal LocationFaction()
        {
        }

        [JsonProperty("Name")]
        [Description("")]
        public string Name { get; internal set; }

        [JsonProperty("FactionState")]
        [Description("")]
        public string FactionState { get; internal set; }

        [JsonProperty("Government")]
        [Description("")]
        public string Government { get; internal set; }

        [JsonProperty("Influence")]
        [Description("")]
        public double Influence { get; internal set; }

        [JsonProperty("Allegiance")]
        [Description("")]
        public string Allegiance { get; internal set; }

        [JsonProperty("PendingStates")]
        [Description("")]
        public List<LocationPendingState> PendingStatesList { get; internal set; }

        [JsonProperty("RecoveringStates")]
        [Description("")]
        public List<LocationRecoveringState> RecoveringStatesList { get; internal set; }
    }
}