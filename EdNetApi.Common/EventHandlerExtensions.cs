// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventHandlerExtensions.cs" company="Martin Amareld">
//   Copyright(c) 2017 Martin Amareld. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EdNetApi.Common
{
    using System;

    public static class EventHandlerExtensions
    {
        public static void Raise<T>(this EventHandler<T> eventHandler, object sender, T eventArgs)
            where T : EventArgs
        {
            var eventHandlerLocal = eventHandler;
            eventHandlerLocal?.Invoke(sender, eventArgs);
        }
    }
}