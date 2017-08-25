// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReceiveTextJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

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
        [Description("")]
        public string FromId { get; internal set; }

        [JsonProperty("Message")]
        [Description("")]
        public string MessageId { get; internal set; }

        [JsonProperty("Message_Localised")]
        [Description("")]
        public string Message { get; internal set; }

        [JsonProperty("Channel")]
        [Description("(wing/local/voicechat/friend/player/npc)")]
        public string Channel { get; internal set; }

        [JsonProperty("From_Localised")]
        [Description("")]
        public string From { get; internal set; }
    }
}