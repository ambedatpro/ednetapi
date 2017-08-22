// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StartJumpJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class StartJumpJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.StartJump;

        internal StartJumpJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("JumpType")]
        public string JumpTypeRaw { get; internal set; }

        [JsonIgnore]
        public JumpType JumpType => JumpTypeRaw.GetEnumValue<JumpType>();

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("StarClass")]
        public string StarClass { get; internal set; }
    }
}