using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalTimer : ITimer, IPausable
{
    //TODO Infinite timer
    private TimeSpan _duration;
    private TimeSpan _tickTime;
    private DateTime _timeAtStart;

    private bool _isPaused;

    private int _maxTickCount;

    //TODO actions
    public IntervalTimer(TimeSpan duration, TimeSpan tickTime, int maxTickCount = -1)
    {
        if (tickTime >= duration)
        {
            Debug.LogError("tickTime should be less than duration");
        }
        _duration = duration;
        _tickTime = tickTime;
        _maxTickCount = maxTickCount;
    }

    public bool IsRunning
    {
        get;
        private set;
    }

    public TimeSpan TimePassedFromStart
    {
        get
        {
            return CurrentTime - _timeAtStart;
        }
    }

    private DateTime CurrentTime
    {
        get
        {
            return DateTime.Now;
        }
    }

    private float TimeLeftSeconds
    {
        get
        {
            return (float)(_duration.TotalSeconds - TimePassedFromStart.TotalSeconds);
        }
    }

    public event TimerEventHandler OnExpired;
    public event TimerEventHandler OnTimerTick;

    public void Start()
    {
        if (!IsRunning)
        {
            IsRunning = true;
            TimerManager.Instance.StartCoroutine(TickTimer());
        }
    }

    public void Stop()
    {
        if (IsRunning)
        {
            IsRunning = false;
            TimerManager.Instance.StopCoroutine(TickTimer());
        }
    }

    public void Pause()
    {
        if (!_isPaused && IsRunning)
        {
            _isPaused = true;
        }
    }

    public void UnPause()
    {
        if (_isPaused)
        {
            _isPaused = false;
        }
    }

    private IEnumerator TickTimer()
    {
        _timeAtStart = CurrentTime;
        float tickTimeSecond = (float)_tickTime.TotalSeconds;

        int tickCount = 0;
        int maxTickCount = (int)(TimeLeftSeconds / tickTimeSecond);
        if (_maxTickCount != -1)
        {
            maxTickCount = _maxTickCount;
        }

        while (IsRunning && TimeLeftSeconds > 0)
        {
            yield return new WaitForSeconds(Mathf.Min(TimeLeftSeconds, tickTimeSecond));
            if (tickCount < maxTickCount)
            {
                tickCount++;
                OnTimerTick.Invoke();
            }
        }
        if (IsRunning)
        {
            OnExpired.Invoke();
        }
        Stop();
    }
}
