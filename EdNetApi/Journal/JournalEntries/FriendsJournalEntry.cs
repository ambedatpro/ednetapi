// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FriendsJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

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
        [Description("one of the following: Requested, Declined, Added, Lost, Offline, Online")]
        public string StatusRaw { get; internal set; }

        [JsonIgnore]
        [Description("one of the following: Requested, Declined, Added, Lost, Offline, Online")]
        public FriendStatus Status => StatusRaw.GetEnumValue<FriendStatus>();

        [JsonProperty("Name")]
        [Description("the friend's commander name")]
        public string Name { get; internal set; }
    }
}