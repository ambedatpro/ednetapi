// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LiftoffJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class LiftoffJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Liftoff;

        internal LiftoffJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("PlayerControlled")]
        [Description("(bool) false if ship dismissed when player is in SRV, true if player is taking off")]
        public bool PlayerControlled { get; internal set; }

        [JsonProperty("Latitude")]
        [Description("")]
        public double Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        [Description("")]
        public double Longitude { get; internal set; }
    }
}