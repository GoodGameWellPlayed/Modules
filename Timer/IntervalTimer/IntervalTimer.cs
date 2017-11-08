using System.Collections;
using UnityEngine;

namespace Components.Timer
{
    public class IntervalTimer : ITimer, IPausable, ITickActionHandler
    {
        public bool IsRunning { get; private set; }

        public event TimerAction OnTickTimer;

        private float _interval;
        private StopWatch _stopWatch;
        private float _interruptedInterval;
        private bool _isPaused;
        private IEnumerator _coroutine;
        private bool _shouldInvokeOnFirstTick;

        public IntervalTimer(float interval, bool shouldInvokeOnFirstTick = false, ITimeGetter timeGetter = null)
        {
            _interval = interval;
            _stopWatch = new StopWatch(timeGetter);
            IsRunning = false;
            _coroutine = UpdateTimer();
            _shouldInvokeOnFirstTick = shouldInvokeOnFirstTick;
        }

        public void Start()
        {
            if (IsRunning)
            {
                Stop();
            }
            IsRunning = true;
            TimerManager.Instance.StartCoroutine(_coroutine);
        }

        public void Stop()
        {
            if (IsRunning)
            {
                TimerManager.Instance.StopCoroutine(_coroutine);
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

                TimerManager.Instance.StartCoroutine(_coroutine);
            }
        }

        public void Pause()
        {
            if (IsRunning && !_isPaused)
            {
                _isPaused = true;

                TimerManager.Instance.StopCoroutine(_coroutine);
                _stopWatch.Stop();
                _interruptedInterval += _stopWatch.TimeInSeconds;
            }
        }

        private IEnumerator UpdateTimer()
        {
            if (_shouldInvokeOnFirstTick)
            {
                InvokeEvent();
            }

            while (IsRunning)
            {
                float currentInterval = _interval - _interruptedInterval;
                _stopWatch.Start();
                yield return new WaitForSeconds(currentInterval);

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

