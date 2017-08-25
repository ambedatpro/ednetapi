// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Feedback.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Information.Database
{
    using System;

    using ServiceStack.DataAnnotations;

    internal class Feedback
    {
        [AutoIncrement]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        [Index(unique: true)]
        public string Message { get; set; }
    }
}