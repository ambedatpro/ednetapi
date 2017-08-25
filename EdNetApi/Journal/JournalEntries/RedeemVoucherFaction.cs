// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RedeemVoucherFaction.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System.ComponentModel;
    using Newtonsoft.Json;

    public class RedeemVoucherFaction
    {
        internal RedeemVoucherFaction()
        {
        }

        [JsonProperty("Faction")]
        [Description("name of faction (for types other than Bounty)")]
        public string Faction { get; internal set; }

        [JsonProperty("Amount")]
        [Description("(Net amount received, after any broker fee)")]
        public int Amount { get; internal set; }
    }
}