// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationFaction.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class LocationFaction
    {
        internal LocationFaction()
        {
        }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }

        [JsonProperty("Government")]
        public string Government { get; internal set; }

        [JsonProperty("Influence")]
        public double Influence { get; internal set; }

        [JsonProperty("Allegiance")]
        public string Allegiance { get; internal set; }

        [JsonProperty("PendingStates")]
        public List<LocationPendingState> PendingStatesList { get; internal set; }

        [JsonProperty("RecoveringStates")]
        public List<LocationRecoveringState> RecoveringStatesList { get; internal set; }
    }
}