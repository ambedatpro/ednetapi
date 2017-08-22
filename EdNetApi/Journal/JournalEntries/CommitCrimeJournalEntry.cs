// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommitCrimeJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

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
        public string CrimeType { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Victim")]
        public string VictimId { get; internal set; }

        [JsonProperty("Victim_Localised")]
        public string Victim { get; internal set; }

        [JsonProperty("Bounty")]
        public int Bounty { get; internal set; }

        [JsonProperty("Fine")]
        public int Fine { get; internal set; }
    }
}