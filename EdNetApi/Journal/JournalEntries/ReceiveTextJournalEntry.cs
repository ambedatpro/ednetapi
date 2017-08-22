// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReceiveTextJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class ReceiveTextJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.ReceiveText;

        internal ReceiveTextJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("From")]
        public string FromId { get; internal set; }

        [JsonProperty("Message")]
        public string MessageId { get; internal set; }

        [JsonProperty("Message_Localised")]
        public string Message { get; internal set; }

        [JsonProperty("Channel")]
        public string Channel { get; internal set; }

        [JsonProperty("From_Localised")]
        public string From { get; internal set; }
    }
}