// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HullDamageJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class HullDamageJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.HullDamage;

        internal HullDamageJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Health")]
        [Description("")]
        public double Health { get; internal set; }

        [JsonProperty("PlayerPilot")]
        [Description("bool – true if player is piloting the ship/fighter taking damage")]
        public bool PlayerPilot { get; internal set; }

        [JsonProperty("Fighter")]
        [Description("bool – true for ship-launched fighter")]
        public bool Fighter { get; internal set; }
    }
}