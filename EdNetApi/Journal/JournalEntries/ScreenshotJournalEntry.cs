// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScreenshotJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class ScreenshotJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Screenshot;

        internal ScreenshotJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("Filename")]
        [Description("filename of screenshot")]
        public string Filename { get; internal set; }

        [JsonProperty("Width")]
        [Description("size in pixels")]
        public int Width { get; internal set; }

        [JsonProperty("Height")]
        [Description("size in pixels")]
        public int Height { get; internal set; }

        [JsonProperty("System")]
        [Description("current star system")]
        public string System { get; internal set; }

        [JsonProperty("Body")]
        [Description("name of nearest body")]
        public string Body { get; internal set; }
    }
}