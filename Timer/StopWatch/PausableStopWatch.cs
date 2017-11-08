namespace Components.Timer
{
    public class PausableStopWatch : ITimer, IPausable
    {
        private StopWatch _pauseWatch;
        private StopWatch _runWatch;

        private float _timeStart;
        private float _timeBeforePause;
        private float _totalPauseTime;

        public bool IsRunning { get { return _runWatch.IsRunning; } }
        private bool IsPaused { get { return _pauseWatch.IsRunning; } }

        public PausableStopWatch(ITimeGetter timeGetter)
        {
            _runWatch = new StopWatch(timeGetter);
            _pauseWatch = new StopWatch(timeGetter);
        }

        public void Start()
        {
            Stop();

            _runWatch.Start();
            _totalPauseTime = 0;
        }

        public void Stop()
        {
            if (IsRunning)
            {
                UnPause();
                _runWatch.Stop();
            }
        }

        public void Pause()
        {
            if (IsRunning && !IsPaused)
            {
                _pauseWatch.Start();
            }
        }

        public void UnPause()
        {
            if (IsRunning && IsPaused)
            {
                _pauseWatch.Stop();
                _totalPauseTime += _pauseWatch.TimeInSeconds;
            }
        }

        public float TimeInSeconds
        {
            get
            {
                return _runWatch.TimeInSeconds - _totalPauseTime - (IsPaused ? _pauseWatch.TimeInSeconds : 0);
            }
        }
    }
}

