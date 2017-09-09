using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void TimerEventHandler();

public interface ITimer
{
    void Start();

    event TimerEventHandler OnExpired;

    event TimerEventHandler OnTimerTick;

    void Stop();

    bool IsRunning { get; }

    TimeSpan TimePassedFromStart { get; }
}
