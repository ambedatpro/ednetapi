// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LastProcessedJournal.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information.Database
{
    internal class LastProcessedJournal
    {
        public string Filename { get; set; }

        public int LineNumber { get; set; }
    }
}