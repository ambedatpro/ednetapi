// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternalException.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Journal
{
    using System;

    public class ExternalException : Exception
    {
        public ExternalException(Exception innerException)
            : base(null, innerException)
        {
        }
    }
}