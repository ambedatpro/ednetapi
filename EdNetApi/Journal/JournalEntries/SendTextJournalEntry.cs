// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendTextJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

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
        [Description("")]
        public string To { get; internal set; }

        [JsonProperty("Message")]
        [Description("")]
        public string Message { get; internal set; }
    }
}