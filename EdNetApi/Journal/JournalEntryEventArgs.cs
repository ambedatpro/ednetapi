// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournalEntryEventArgs.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal
{
    using System;

    public class JournalEntryEventArgs : EventArgs
    {
        internal JournalEntryEventArgs(string filename, int lineNumber, JournalEntry journalEntry, bool isLive)
        {
            Filename = filename;
            LineNumber = lineNumber;
            JournalEntry = journalEntry;
            IsLive = isLive;
        }

        public string Filename { get; }

        public int LineNumber { get; }

        public JournalEntry JournalEntry { get; }

        public bool IsLive { get; }
    }
}