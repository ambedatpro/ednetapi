// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketBuyJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class MarketBuyJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.MarketBuy;

        internal MarketBuyJournalEntry()
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

        [JsonProperty("BuyPrice")]
        public int BuyPrice { get; internal set; }

        [JsonProperty("TotalCost")]
        public int TotalCost { get; internal set; }
    }
}