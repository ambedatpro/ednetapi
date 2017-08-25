// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterdictedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class InterdictedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Interdicted;

        internal InterdictedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Submitted")]
        [Description("true or false")]
        public bool Submitted { get; internal set; }

        [JsonProperty("Interdictor")]
        [Description("interdicting pilot name")]
        public string Interdictor { get; internal set; }

        [JsonProperty("IsPlayer")]
        [Description("whether player or npc")]
        public bool IsPlayer { get; internal set; }

        [JsonProperty("Faction")]
        [Description("if npc")]
        public string Faction { get; internal set; }
    }
}