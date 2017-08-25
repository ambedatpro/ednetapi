// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionFailedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class MissionFailedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.MissionFailed;

        internal MissionFailedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Name")]
        [Description("name of mission")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        [Description("")]
        public int MissionId { get; internal set; }
    }
}