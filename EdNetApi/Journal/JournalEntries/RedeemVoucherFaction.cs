// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RedeemVoucherFaction.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using Newtonsoft.Json;

    public class RedeemVoucherFaction
    {
        internal RedeemVoucherFaction()
        {
        }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Amount")]
        public int Amount { get; internal set; }
    }
}