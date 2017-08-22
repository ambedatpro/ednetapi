// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal
{
    using System;

    public abstract class JournalEntry
    {
        public abstract JournalEventType Event { get; }

        public abstract DateTime Timestamp { get; internal set; }

        public string SourceJson { get; internal set; }
    }
}