using UnityEngine;

namespace Components.Timer
{
    public class RealtimeStopWatch : IStopWatch
    {
        private float _timeStart;

        public bool IsRunning { get; private set; }

        public RealtimeStopWatch()
        {
            IsRunning = false;
        }

        public void Start()
        {
            IsRunning = true;
            _timeStart = Time.realtimeSinceStartup;
        }

        public float Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                return Time.realtimeSinceStartup - _timeStart;
            }
            else
            {
                return 0;
            }
        }
    }
}

