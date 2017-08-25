// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UndockedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class UndockedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Undocked;

        internal UndockedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("StationName")]
        [Description("name of station")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        [Description("")]
        public string StationType { get; internal set; }
    }
}