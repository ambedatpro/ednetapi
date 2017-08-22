// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FsdJumpFaction.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class FsdJumpFaction
    {
        internal FsdJumpFaction()
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
        public List<FsdJumpPendingState> PendingStatesList { get; internal set; }

        [JsonProperty("RecoveringStates")]
        public List<FsdJumpRecoveringState> RecoveringStatesList { get; internal set; }
    }
}