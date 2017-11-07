namespace Components.Timer
{
    public delegate void TimerEventHandler(object arguments);

    public interface ITimer : IPausable
    {
        void Start();
        void Stop();

        bool IsRunning { get; }
    }

    public interface ITickTimer : ITimer
    {
        event TimerEventHandler OnTickEvent;
    }

    public interface IExpirationTimer : ITimer
    {
        event TimerEventHandler OnExpirationEvent;
    }
}

