// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEventStatistics.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information
{
    using EdNetApi.Journal;

    public interface IEventStatistics
    {
        JournalEventType Event { get; }

        string Commander { get; }

        string StarSystem { get; }

        string StationName { get; }

        string Name { get; }

        string Faction { get; }

        string BodyType { get; }

        string Body { get; }

        string Ship { get; }

        string Interdictor { get; }

        string Interdicted { get; }

        string KillerName { get; }

        string KillerShip { get; }

        string Victim { get; }
    }
}