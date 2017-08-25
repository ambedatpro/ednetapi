// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaterialsJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class MaterialsJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Materials;

        internal MaterialsJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Manufactured")]
        [Description("array of manufactured items")]
        public List<MaterialsManufactured> ManufacturedList { get; internal set; }

        [JsonProperty("Encoded")]
        [Description("array of scanned data")]
        public List<MaterialsEncoded> EncodedList { get; internal set; }
    }
}