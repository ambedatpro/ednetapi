// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatalinkVoucherJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class DatalinkVoucherJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.DatalinkVoucher;

        internal DatalinkVoucherJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Reward")]
        [Description("value in credits")]
        public int Reward { get; internal set; }

        [JsonProperty("VictimFaction")]
        [Description("")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("PayeeFaction")]
        [Description("")]
        public string PayeeFaction { get; internal set; }
    }
}