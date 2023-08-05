using System;
using CustomTimer.EventArgsClasses;
using CustomTimer.Interfaces;

namespace CustomTimer.Implementation
{
    public class CountDownNotifier : ICountDownNotifier
    {
#pragma warning disable SA1309
        private readonly Timer _timer;
#pragma warning restore SA1309

        public CountDownNotifier(Timer timer)
        {
            this._timer = timer;
        }

        public void Init(EventHandler<StartedEventArgs>? startHandler, EventHandler<StoppedEventArgs>? stopHandler, EventHandler<TickEventArgs>? tickHandler)
        {
            this._timer.Started += startHandler;
            this._timer.Stopped += stopHandler;
            this._timer.Tick += tickHandler;
        }

        public void Run()
        {
            this._timer.Run();
        }
    }
}
