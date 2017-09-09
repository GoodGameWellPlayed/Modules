using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalSpawnBehavior : MonoBehaviour, IArgumentsGenerator
{
    [SerializeField] PoolGroupNameObjectIdPair nameId;
    [SerializeField] int _intervalMsec;
    IntervalTimer _timer;
    bool _shouldSpawn;

    private void OnTick()
    {
        _shouldSpawn = true;
    }

    private void OnExpired()
    {
        _timer.OnTimerTick -= OnTick;
        _timer.OnExpired -= OnExpired;
        _timer = null;
    }

    public IEnumerable<PoolableObjectArguments> GetPoolableArguments()
    {
        if (_timer == null)
        {
            _timer = new IntervalTimer(new TimeSpan(1, 0, 0), new TimeSpan(0, 0, 0, 0, _intervalMsec));
            _timer.OnTimerTick += OnTick;
            _timer.OnExpired += OnExpired;
            _timer.Start();
        }
        if (_shouldSpawn)
        {
            _shouldSpawn = false;
            yield return 
                new PoolableObjectArguments()
                {
                    PoolableObjectGroupNameIndex = nameId
                };
        }
    }
}
