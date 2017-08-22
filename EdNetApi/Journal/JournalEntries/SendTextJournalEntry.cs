// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendTextJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class SendTextJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.SendText;

        internal SendTextJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("To")]
        public string To { get; internal set; }

        [JsonProperty("Message")]
        public string Message { get; internal set; }
    }
}