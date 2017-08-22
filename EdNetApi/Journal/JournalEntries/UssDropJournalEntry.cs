// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UssDropJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class UssDropJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.UssDrop;

        internal UssDropJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("USSType")]
        public string UssTypeId { get; internal set; }

        [JsonProperty("USSType_Localised")]
        public string UssType { get; internal set; }

        [JsonProperty("USSThreat")]
        public int UssThreat { get; internal set; }
    }
}