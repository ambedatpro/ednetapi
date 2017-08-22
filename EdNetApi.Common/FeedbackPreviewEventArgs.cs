// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedbackPreviewEventArgs.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common
{
    using System;

    public class FeedbackPreviewEventArgs : EventArgs
    {
        internal FeedbackPreviewEventArgs(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public bool Handled { get; set; }
    }
}