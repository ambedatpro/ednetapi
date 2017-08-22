// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataScannedJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class DataScannedJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.DataScanned;

        internal DataScannedJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Type")]
        public string TypeRaw { get; internal set; }

        [JsonIgnore]
        public DataLinkType Type => TypeRaw.GetEnumValue<DataLinkType>();
    }
}