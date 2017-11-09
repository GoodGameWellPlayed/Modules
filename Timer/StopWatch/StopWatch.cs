namespace Components.Timer
{
    public class StopWatch : ITimer, IPausable
    {
        private ITimeGetter _timeGetter;
        private float _timeStart;
        private float _timeStop;
        
        private float _totalPauseTime;
        private float _timeBeforePause;

        public bool IsRunning { get; private set; }
        private bool _isPaused;

        public StopWatch(ITimeGetter timeGetter = null)
        {
            IsRunning = false;
            _timeGetter = timeGetter ?? DefaultTimeGetter.Instance;
        }

        public void Start()
        {
            Stop();

            IsRunning = true;

            _timeStart = CurrentTime;
            _totalPauseTime = 0;
            _timeBeforePause = 0;
        }

        public void Stop()
        {
            if (IsRunning)
            {
                UnPause();
                _timeStop = TimeInSeconds;
                IsRunning = false;
            }
        }

        public void Pause()
        {
            if (IsRunning && !_isPaused)
            {
                _isPaused = true;
                _timeBeforePause = CurrentTime;
            }
        }

        public void UnPause()
        {
            if (IsRunning && _isPaused)
            {
                _isPaused = false;
                _totalPauseTime += PauseTime;
            }
        }

        private float PauseTime
        {
            get
            {
                return CurrentTime - _timeBeforePause;
            }
        }

        private float CurrentTime
        {
            get
            {
                return _timeGetter.GetTimeInSeconds;
            }
        }

        public float TimeInSeconds
        {
            get
            {
                float runTime = IsRunning ? CurrentTime - _timeStart : _timeStop;
                float pauseTime = _isPaused ? PauseTime : 0;

                return runTime - _totalPauseTime - pauseTime;
            }
        }
    }
}

