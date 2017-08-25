// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineerCraftJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

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
        [Description("name of engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Blueprint")]
        [Description("name of blueprint")]
        public string Blueprint { get; internal set; }

        [JsonProperty("Level")]
        [Description("crafting level")]
        public int Level { get; internal set; }

        [JsonProperty("Ingredients")]
        [Description("JSON array of objects with names and quantities of materials required")]
        public List<EngineerCraftIngredient> IngredientsList { get; internal set; }
    }
}