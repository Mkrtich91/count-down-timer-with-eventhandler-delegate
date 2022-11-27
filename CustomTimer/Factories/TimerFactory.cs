﻿using System;

namespace CustomTimer.Factories
{
    /// <summary>
    /// Implements the factory method pattern
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/Factory_method_pattern</cref>
    /// </see>
    /// >
    /// for creating an object of the <see cref="Timer"/> class.
    /// </summary>
    public class TimerFactory
    {
        /// <summary>
        /// Create an object of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="name">Name of timer.</param>
        /// <param name="ticks">Count of ticks.</param>
        /// <returns>A reference to an object of the <see cref="Timer"/> class.</returns>
        public Timer CreateTimer(string? name, int ticks)
        {
            throw new NotImplementedException();
        }
    }
}
