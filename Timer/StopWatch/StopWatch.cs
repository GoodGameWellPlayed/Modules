namespace Components.Timer
{
    public class StopWatch : ITimer
    {
        private ITimeGetter _timeGetter;
        private float _timeStart;
        private float _timeStop;

        public bool IsRunning { get; private set; }

        public StopWatch(ITimeGetter timeGetter = null)
        {
            IsRunning = false;
            _timeGetter = timeGetter ?? new DefaultTimeGetter();
        }

        public void Start()
        {
            IsRunning = true;
            _timeStart = CurrentTime;
        }

        public void Stop()
        {
            if (IsRunning)
            {
                _timeStop = TimeInSeconds;
                IsRunning = false;
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
                return IsRunning ? CurrentTime - _timeStart : _timeStop;
            }
        }
    }
}

