// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatalinkScanJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class DatalinkScanJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.DatalinkScan;

        internal DatalinkScanJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Message")]
        [Description("message from data link")]
        public string MessageId { get; internal set; }

        [JsonProperty("Message_Localised")]
        [Description("")]
        public string Message { get; internal set; }
    }
}