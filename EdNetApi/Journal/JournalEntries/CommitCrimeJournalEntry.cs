// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommitCrimeJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class CommitCrimeJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.CommitCrime;

        internal CommitCrimeJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("CrimeType")]
        [Description("")]
        public string CrimeType { get; internal set; }

        [JsonProperty("Faction")]
        [Description("")]
        public string Faction { get; internal set; }

        [JsonProperty("Victim")]
        [Description("")]
        public string VictimId { get; internal set; }

        [JsonProperty("Victim_Localised")]
        [Description("")]
        public string Victim { get; internal set; }

        [JsonProperty("Bounty")]
        [Description("")]
        public int Bounty { get; internal set; }

        [JsonProperty("Fine")]
        [Description("")]
        public int Fine { get; internal set; }
    }
}