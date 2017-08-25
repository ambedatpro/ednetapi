// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScanJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public class ScanJournalEntry : JournalEntry
    {
        public const JournalEventType EventConst = JournalEventType.Scan;

        internal ScanJournalEntry()
        {
        }

        [JsonIgnore]
        public override JournalEventType Event => EventConst;

        [JsonProperty("timestamp")]
        public override DateTime Timestamp { get; internal set; }

        [JsonProperty("BodyName")]
        [Description("name of body")]
        public string BodyName { get; internal set; }

        [JsonProperty("DistanceFromArrivalLS")]
        [Description("")]
        public double DistanceFromArrivalLs { get; internal set; }

        [JsonProperty("StarType")]
        [Description("Stellar classification (for a star) – see 11.2")]
        public string StarType { get; internal set; }

        [JsonProperty("StellarMass")]
        [Description("mass as multiple of Sol’s mass")]
        public double StellarMass { get; internal set; }

        [JsonProperty("Radius")]
        [Description("")]
        public double Radius { get; internal set; }

        [JsonProperty("AbsoluteMagnitude")]
        [Description("")]
        public double AbsoluteMagnitude { get; internal set; }

        [JsonProperty("Age_MY")]
        [Description("age in millions of years")]
        public int Age_My { get; internal set; }

        [JsonProperty("SurfaceTemperature")]
        [Description("")]
        public double SurfaceTemperature { get; internal set; }

        [JsonProperty("SemiMajorAxis")]
        [Description("")]
        public double SemiMajorAxis { get; internal set; }

        [JsonProperty("Eccentricity")]
        [Description("")]
        public double Eccentricity { get; internal set; }

        [JsonProperty("OrbitalInclination")]
        [Description("")]
        public double OrbitalInclination { get; internal set; }

        [JsonProperty("Periapsis")]
        [Description("")]
        public double Periapsis { get; internal set; }

        [JsonProperty("OrbitalPeriod")]
        [Description("")]
        public double OrbitalPeriod { get; internal set; }

        [JsonProperty("RotationPeriod")]
        [Description("")]
        public double RotationPeriod { get; internal set; }

        [JsonProperty("AxialTilt")]
        [Description("")]
        public double AxialTilt { get; internal set; }

        [JsonProperty("PlanetClass")]
        [Description("")]
        public string PlanetClass { get; internal set; }

        [JsonProperty("MassEM")]
        [Description("")]
        public double MassEm { get; internal set; }

        [JsonProperty("SurfaceGravity")]
        [Description("")]
        public double SurfaceGravity { get; internal set; }
    }
}