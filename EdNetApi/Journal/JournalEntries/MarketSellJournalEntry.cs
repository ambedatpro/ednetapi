// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketSellJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

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
        public string Type { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }

        [JsonProperty("SellPrice")]
        public int SellPrice { get; internal set; }

        [JsonProperty("TotalSale")]
        public int TotalSale { get; internal set; }

        [JsonProperty("AvgPricePaid")]
        public int AvgPricePaid { get; internal set; }

        [JsonProperty("StolenGoods")]
        public bool StolenGoods { get; internal set; }

        [JsonProperty("BlackMarket")]
        public bool BlackMarket { get; internal set; }
    }
}