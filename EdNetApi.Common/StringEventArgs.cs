// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringEventArgs.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common
{
    using System;

    public class StringEventArgs : EventArgs
    {
        internal StringEventArgs(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}