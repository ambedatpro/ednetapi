// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class DiedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Died;

        internal DiedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("KillerName")]
        [Description("")]
        public string KillerNameId { get; internal set; }

        [JsonProperty("KillerShip")]
        [Description("")]
        public string KillerShip { get; internal set; }

        [JsonProperty("KillerRank")]
        [Description("")]
        public string KillerRank { get; internal set; }

        [JsonProperty("KillerName_Localised")]
        [Description("")]
        public string KillerName { get; internal set; }
    }
}