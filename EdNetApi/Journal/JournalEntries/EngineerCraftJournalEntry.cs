// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineerCraftJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class EngineerCraftJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.EngineerCraft;

        internal EngineerCraftJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Blueprint")]
        public string Blueprint { get; internal set; }

        [JsonProperty("Level")]
        public int Level { get; internal set; }

        [JsonProperty("Ingredients")]
        public List<EngineerCraftIngredient> IngredientsList { get; internal set; }
    }
}