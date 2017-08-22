// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaterialsEncoded.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using Newtonsoft.Json;

    public class MaterialsEncoded
    {
        internal MaterialsEncoded()
        {
        }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }
    }
}