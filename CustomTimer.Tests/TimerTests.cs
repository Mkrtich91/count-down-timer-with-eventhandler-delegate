﻿using System;
using CustomTimer.Factories;
using NUnit.Framework;

namespace CustomTimer.Tests
{
    [TestFixture]
    public class TimerTests
    {
        private TimerFactory timerFactory = null!;

        [SetUp]
        public void Setup() => this.timerFactory = new TimerFactory();

        [TestCase("")]
        [TestCase(null)]
        public void Ctor_EmptyTimerName_ThrowsArgumentException(string timerName) =>
            Assert.Throws<ArgumentException>(() => this.timerFactory.CreateTimer(timerName, 1));

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void Ctor_InvalidSecondsCount_ThrowsArgumentException(int totalTicks) =>
            Assert.Throws<ArgumentException>(() => this.timerFactory.CreateTimer("tea", totalTicks));
    }
}
