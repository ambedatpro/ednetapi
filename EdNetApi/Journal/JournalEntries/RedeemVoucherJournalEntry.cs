// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RedeemVoucherJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

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
        [Description("(CombatBond/Bounty/Trade/Settlement/Scannable)")]
        public string TypeRaw { get; internal set; }

        [JsonIgnore]
        [Description("(CombatBond/Bounty/Trade/Settlement/Scannable)")]
        public VoucherType Type => TypeRaw.GetEnumValue<VoucherType>();

        [JsonProperty("Amount")]
        [Description("(Net amount received, after any broker fee)")]
        public int Amount { get; internal set; }

        [JsonProperty("Factions")]
        [Description("array of faction/amount pairs (for Type=Bounty)")]
        public List<RedeemVoucherFaction> FactionsList { get; internal set; }
    }
}