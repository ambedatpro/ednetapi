// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PowerplayJoinJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class PowerplayJoinJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.PowerplayJoin;

        internal PowerplayJoinJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Power")]
        [Description("")]
        public string Power { get; internal set; }
    }
}