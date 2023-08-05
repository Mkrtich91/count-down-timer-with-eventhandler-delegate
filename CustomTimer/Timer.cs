using System;
using CustomTimer.EventArgsClasses;

namespace CustomTimer
{
    /// <summary>
    /// A custom class for simulating a countdown clock, which implements the ability to send a messages and additional
    /// information about the Started, Tick and Stopped events to any types that are subscribing the specified events.
    /// - When creating a CustomTimer object, it must be assigned:
    ///     - name (not null or empty string, otherwise ArgumentException will be thrown);
    ///     - the number of ticks (the number must be greater than 0 otherwise an exception will throw an ArgumentException).
    /// - After the timer has been created, it should fire the Started event, the event should contain information about
    /// the name of the timer and the number of ticks to start.
    /// - After starting the timer, it fires Tick events, which contain information about the name of the timer and
    /// the number of ticks left for triggering, there should be delays between Tick events, delays are modeled by Thread.Sleep.
    /// - After all Tick events are triggered, the timer should start the Stopped event, the event should contain information about
    /// the name of the timer.
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="timerName">Name.</param>
        /// <param name="ticks">Ticks.</param>
        public event EventHandler<StartedEventArgs> Started;

        public event EventHandler<TickEventArgs> Tick;

        public event EventHandler<StoppedEventArgs> Stopped;

        public string Name { get; }

        public int Ticks { get; }

#pragma warning disable CS8618
#pragma warning disable SA1201
        public Timer(string name, int ticks)
#pragma warning restore SA1201
#pragma warning restore CS8618
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }

            if (ticks <= 0)
            {
                throw new ArgumentException("Number of ticks has to be greater than 0.");
            }

            this.Name = name;
            this.Ticks = ticks;
        }

        public void Run()
        {
            this.OnStarted();

            for (int tick = this.Ticks; tick > 0; tick--)
            {
                this.OnTick(tick - 1);
                Thread.Sleep(1000);
            }

            this.OnStopped();
        }

        protected virtual void OnStarted()
        {
            this.Started?.Invoke(this, new StartedEventArgs(this.Name, this.Ticks));
        }

        protected virtual void OnTick(int ticksLeft)
        {
            this.Tick?.Invoke(this, new TickEventArgs(this.Name, ticksLeft));
        }

        protected virtual void OnStopped()
        {
            this.Stopped?.Invoke(this, new StoppedEventArgs(this.Name));
        }
    }
}
