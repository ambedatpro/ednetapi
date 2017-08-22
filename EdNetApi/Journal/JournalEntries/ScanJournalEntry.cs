// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScanJournalEntry.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal.JournalEntries
{
    using System;

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
        public string BodyName { get; internal set; }

        [JsonProperty("DistanceFromArrivalLS")]
        public double DistanceFromArrivalLs { get; internal set; }

        [JsonProperty("StarType")]
        public string StarType { get; internal set; }

        [JsonProperty("StellarMass")]
        public double StellarMass { get; internal set; }

        [JsonProperty("Radius")]
        public double Radius { get; internal set; }

        [JsonProperty("AbsoluteMagnitude")]
        public double AbsoluteMagnitude { get; internal set; }

        [JsonProperty("Age_MY")]
        public int Age_My { get; internal set; }

        [JsonProperty("SurfaceTemperature")]
        public double SurfaceTemperature { get; internal set; }

        [JsonProperty("SemiMajorAxis")]
        public double SemiMajorAxis { get; internal set; }

        [JsonProperty("Eccentricity")]
        public double Eccentricity { get; internal set; }

        [JsonProperty("OrbitalInclination")]
        public double OrbitalInclination { get; internal set; }

        [JsonProperty("Periapsis")]
        public double Periapsis { get; internal set; }

        [JsonProperty("OrbitalPeriod")]
        public double OrbitalPeriod { get; internal set; }

        [JsonProperty("RotationPeriod")]
        public double RotationPeriod { get; internal set; }

        [JsonProperty("AxialTilt")]
        public double AxialTilt { get; internal set; }

        [JsonProperty("PlanetClass")]
        public string PlanetClass { get; internal set; }

        [JsonProperty("MassEM")]
        public double MassEm { get; internal set; }

        [JsonProperty("SurfaceGravity")]
        public double SurfaceGravity { get; internal set; }
    }
}