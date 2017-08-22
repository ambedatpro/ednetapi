// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShipData.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information.Datas
{
    using EdNetApi.Journal.Enums;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using ServiceStack.DataAnnotations;

    public class ShipData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ShipType Ship { get; internal set; }

        [Ignore]
        public string ShipName { get; internal set; }

        [Ignore]
        public string ShipIdent { get; internal set; }
    }
}