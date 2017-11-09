namespace Components.Timer
{
    public class ExpirationTimer : ITimer, IPausable
    {
        private IntervalTimer _intervalTimer;

        public bool IsRunning { get { return _intervalTimer.IsRunning; } }
        public float ExpirationTime
        {
            get
            {
                return _intervalTimer.Interval;
            }
            set
            {
                _intervalTimer.Interval = value;
            }
        }

        public event TimerAction OnExpiredTimer;

        public ExpirationTimer(float time, bool shouldChangeTimeImmediate = false, 
            ITimeGetter timeGetter = null)
        {
            _intervalTimer = new IntervalTimer(time, false, shouldChangeTimeImmediate, timeGetter);
            _intervalTimer.OnTickTimer += TimerTick;
        }

        private void TimerTick()
        {
            if (OnExpiredTimer != null)
            {
                OnExpiredTimer.Invoke();
            }
            Stop();
        }

        public void Start()
        {
            _intervalTimer.Start();
        }

        public void Stop()
        {
            _intervalTimer.Stop();
        }

        public void Pause()
        {
            _intervalTimer.Pause();
        }

        public void UnPause()
        {
            _intervalTimer.UnPause();
        }

    }
}

