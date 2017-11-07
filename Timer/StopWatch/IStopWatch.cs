namespace Components.Timer
{
    public interface IStopWatch
    {
        void Start();
        float Stop();
        bool IsRunning { get; }
    }
}

