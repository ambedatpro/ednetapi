// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LatestEvent.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information.Database
{
    using EdNetApi.Journal;

    using ServiceStack.DataAnnotations;

    public class LatestEvent
    {
        [AutoIncrement]
        public int Id { get; set; }

        [Index(Unique = true)]
        public JournalEventType EventType { get; set; }

        public string JournalEntryJson { get; set; }
    }
}