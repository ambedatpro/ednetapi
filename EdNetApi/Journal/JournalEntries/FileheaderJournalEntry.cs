// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileheaderJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class FileheaderJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Fileheader;

        internal FileheaderJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("part")]
        [Description("")]
        public int Part { get; internal set; }

        [JsonProperty("language")]
        [Description("")]
        public string Language { get; internal set; }

        [JsonProperty("gameversion")]
        [Description("")]
        public string Gameversion { get; internal set; }

        [JsonProperty("build")]
        [Description("")]
        public string Build { get; internal set; }
    }
}