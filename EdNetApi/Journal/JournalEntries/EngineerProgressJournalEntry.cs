// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineerProgressJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class EngineerProgressJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.EngineerProgress;

        internal EngineerProgressJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Progress")]
        public string ProgressRaw { get; internal set; }

        [JsonIgnore]
        public ProgressState Progress => ProgressRaw.GetEnumValue<ProgressState>();

        [JsonProperty("Rank")]
        public int Rank { get; internal set; }
    }
}