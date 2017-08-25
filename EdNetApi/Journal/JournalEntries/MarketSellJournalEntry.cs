// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketSellJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class MarketSellJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.MarketSell;

        internal MarketSellJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Type")]
        [Description("cargo type")]
        public string Type { get; internal set; }

        [JsonProperty("Count")]
        [Description("number of units")]
        public int Count { get; internal set; }

        [JsonProperty("SellPrice")]
        [Description("price per unit")]
        public int SellPrice { get; internal set; }

        [JsonProperty("TotalSale")]
        [Description("total sale value")]
        public int TotalSale { get; internal set; }

        [JsonProperty("AvgPricePaid")]
        [Description("average price paid")]
        public int AvgPricePaid { get; internal set; }

        [JsonProperty("StolenGoods")]
        [Description("(not always present) whether goods were stolen")]
        public bool StolenGoods { get; internal set; }

        [JsonProperty("BlackMarket")]
        [Description("(not always present) whether selling in a black market")]
        public bool BlackMarket { get; internal set; }
    }
}