// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCommanderJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class NewCommanderJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.NewCommander;

        internal NewCommanderJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Name")]
        [Description("(new) commander name")]
        public string Name { get; internal set; }

        [JsonProperty("Package")]
        [Description("selected starter package")]
        public string Package { get; internal set; }
    }
}