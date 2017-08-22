// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineerApplyJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class EngineerApplyJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.EngineerApply;

        internal EngineerApplyJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Blueprint")]
        public string Blueprint { get; internal set; }

        [JsonProperty("Level")]
        public int Level { get; internal set; }
    }
}