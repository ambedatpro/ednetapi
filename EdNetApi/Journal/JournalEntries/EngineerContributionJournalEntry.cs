// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineerContributionJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class EngineerContributionJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.EngineerContribution;

        internal EngineerContributionJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Type")]
        public string TypeRaw { get; internal set; }

        [JsonIgnore]
        public ContributionType Type => TypeRaw.GetEnumValue<ContributionType>();

        [JsonProperty("Commodity")]
        public string Commodity { get; internal set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; internal set; }

        [JsonProperty("TotalQuantity")]
        public int TotalQuantity { get; internal set; }
    }
}