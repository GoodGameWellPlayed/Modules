namespace Components.Timer
{
    public class ExpirationTimer : ITimer, IPausable, IExpiredActionHandler
    {
        private IntervalTimer _intervaTimer;

        public bool IsRunning { get { return _intervaTimer.IsRunning; } }

        public event TimerAction OnExpiredTimer;

        public ExpirationTimer(float time, ITimeGetter timeGetter = null)
        {
            _intervaTimer = new IntervalTimer(time, false, timeGetter);
            _intervaTimer.OnTickTimer += TimerTick;
        }

        private void TimerTick()
        {
            if (OnExpiredTimer != null)
            {
                OnExpiredTimer.Invoke();
            }
            _intervaTimer.Stop();
        }

        public void Pause()
        {
            _intervaTimer.Pause();
        }

        public void Stop()
        {
            _intervaTimer.Stop();
        }

        public void UnPause()
        {
            _intervaTimer.UnPause();
        }

        public void Start()
        {
            _intervaTimer.Start();
        }
    }
}

