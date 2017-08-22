// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuyAmmoJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using Newtonsoft.Json;

    public class BuyAmmoJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.BuyAmmo;

        internal BuyAmmoJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Cost")]
        public int Cost { get; internal set; }
    }
}