// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal
{
    using System;

    using Newtonsoft.Json;

    public class UnknownJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.UnknownValue;

        internal UnknownJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonIgnore]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("ParseError")]
        public string ParseError { get; internal set; }
    }
}