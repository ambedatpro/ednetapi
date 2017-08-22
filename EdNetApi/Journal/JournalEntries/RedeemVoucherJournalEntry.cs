// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RedeemVoucherJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class RedeemVoucherJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.RedeemVoucher;

        internal RedeemVoucherJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Type")]
        public string TypeRaw { get; internal set; }

        [JsonIgnore]
        public VoucherType Type => TypeRaw.GetEnumValue<VoucherType>();

        [JsonProperty("Amount")]
        public int Amount { get; internal set; }

        [JsonProperty("Factions")]
        public List<RedeemVoucherFaction> FactionsList { get; internal set; }
    }
}