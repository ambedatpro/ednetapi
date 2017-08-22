// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PowerplayLeaveJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class PowerplayLeaveJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.PowerplayLeave;

        internal PowerplayLeaveJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Power")]
        public string Power { get; internal set; }
    }
}