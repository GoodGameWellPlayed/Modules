using System.Collections;
using UnityEngine;

namespace Components.Timer
{
    public class IntervalTimer : ITickTimer
    {
        public bool IsRunning { get; private set; }

        public event TimerEventHandler OnTickEvent;

        private float _interval;
        private IStopWatch _stopWatch;
        private float _interruptedInterval;
        private bool _isPaused;
        private Coroutine _coroutine;
        private bool _shouldInvokeOnFirstTick;

        public IntervalTimer(float interval, bool invokeOnFirstTick = false)
        {
            _interval = interval;
            _stopWatch = new RealtimeStopWatch();
            IsRunning = false;
            _shouldInvokeOnFirstTick = invokeOnFirstTick;
        }

        public void Start()
        {
            if (IsRunning)
            {
                Stop();
            }
            IsRunning = true;
            _coroutine = TimerManager.Instance.StartCoroutine(UpdateTimer());
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

                _coroutine = TimerManager.Instance.StartCoroutine(UpdateTimer());
            }
        }

        public void Pause()
        {
            if (IsRunning && !_isPaused)
            {
                _isPaused = true;

                TimerManager.Instance.StopCoroutine(_coroutine);
                _interruptedInterval += _stopWatch.Stop();
            }
        }

        private IEnumerator UpdateTimer()
        {
            if (_shouldInvokeOnFirstTick)
            {
                InvokeTick();
            }

            while (IsRunning)
            {
                float currentInterval = _interval - _interruptedInterval;
                _stopWatch.Start();
                yield return new WaitForSeconds(currentInterval);

                InvokeTick();
                _interruptedInterval = 0;
            }
        }

        private void InvokeTick()
        {
            if (OnTickEvent != null)
            {
                OnTickEvent.Invoke(null);
            }
        }
    }
}

