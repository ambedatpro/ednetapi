// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendsJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

    using EdNetApi.Common;
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;

    public class FriendsJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Friends;

        internal FriendsJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Status")]
        public string StatusRaw { get; internal set; }

        [JsonIgnore]
        public FriendStatus Status => StatusRaw.GetEnumValue<FriendStatus>();

        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}