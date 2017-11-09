namespace Components.Timer
{
    public delegate void TimerAction();

    public interface ITimer
    {
        void Start();
        void Stop();

        bool IsRunning { get; }
    }
}

