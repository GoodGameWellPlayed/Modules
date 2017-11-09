using System.Collections;
using UnityEngine;

namespace Components.Timer
{
    public class IntervalTimer : ITimer, IPausable
    {
        public bool IsRunning { get; private set; }
        public float Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                if (IsRunning && !_isPaused && _shouldChangeIntervalImmediate)
                {
                    Pause();
                    UnPause();
                }
            }
        }

        public event TimerAction OnTickTimer;

        private float _interval;
        private StopWatch _stopWatch;
        private float _interruptedInterval;
        private bool _isPaused;
        private Coroutine _coroutine;
        private bool _shouldInvokeOnStart;
        private bool _shouldChangeIntervalImmediate;

        public IntervalTimer(float interval, bool shouldInvokeOnStart = false, 
            bool shouldChangeIntervalImmediate = true, ITimeGetter timeGetter = null)
        {
            _interval = interval;
            _stopWatch = new StopWatch(timeGetter);
            IsRunning = false;
            _shouldInvokeOnStart = shouldInvokeOnStart;
            _shouldChangeIntervalImmediate = shouldChangeIntervalImmediate;
        }

        private void StartCoroutine()
        {
            _coroutine = TimerManager.Instance.StartCoroutine(UpdateTimer());
        }

        private void StopCoroutine()
        {
            TimerManager.Instance.StopCoroutine(_coroutine);
        }

        public void Start()
        {
            if (IsRunning)
            {
                Stop();
            }
            IsRunning = true;

            if (_shouldInvokeOnStart)
            {
                InvokeEvent();
            }
            StartCoroutine();
        }

        public void Stop()
        {
            if (IsRunning)
            {
                StopCoroutine();
                IsRunning = false;

                _stopWatch.Stop();
                _isPaused = false;
                _interruptedInterval = 0;
            }
        }

        public void UnPause()
        {
            if (IsRunning && _isPaused)
            {
                _isPaused = false;

                StartCoroutine();
            }
        }

        public void Pause()
        {
            if (IsRunning && !_isPaused)
            {
                _isPaused = true;

                StopCoroutine();
                _stopWatch.Stop();
                _interruptedInterval += _stopWatch.TimeInSeconds;
            }
        }

        private IEnumerator UpdateTimer()
        {
            while (IsRunning)
            {
                float currentInterval = _interval - _interruptedInterval;
                _stopWatch.Start();
                if (currentInterval > 0)
                {
                    yield return new WaitForSeconds(currentInterval);
                }
                InvokeEvent();

                _interruptedInterval = 0;
            }
        }

        private void InvokeEvent()
        {
            if (OnTickTimer != null)
            {
                OnTickTimer.Invoke();
            }
        }
    }
}

