// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournalEntrySource.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information.Database
{
    using ServiceStack.DataAnnotations;

    [CompositeIndex(true, nameof(Filename), nameof(LineNumber))]
    internal class JournalEntrySource
    {
        [AutoIncrement]
        public int Id { get; set; }

        public string Filename { get; set; }

        public int LineNumber { get; set; }

        public bool Parsed { get; set; }

        public string Json { get; set; }
    }
}