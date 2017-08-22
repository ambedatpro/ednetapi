// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeatWarningJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class HeatWarningJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.HeatWarning;

        internal HeatWarningJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }
    }
}