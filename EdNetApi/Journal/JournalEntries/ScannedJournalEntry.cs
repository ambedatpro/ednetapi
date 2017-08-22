// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScannedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class ScannedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Scanned;

        internal ScannedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("ScanType")]
        public string ScanTypeRaw { get; internal set; }

        [JsonIgnore]
        public ScanType ScanType => ScanTypeRaw.GetEnumValue<ScanType>();
    }
}