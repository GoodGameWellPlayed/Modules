using UnityEngine;

namespace Components.Timer
{
    public class DefaultTimeGetter : ITimeGetter
    {
        public static DefaultTimeGetter Instance = new DefaultTimeGetter();

        public float GetTimeInSeconds { get { return Time.time; } }
    }

    public class RealTimeGetter : ITimeGetter
    {
        public static RealTimeGetter Instance = new RealTimeGetter();

        public float GetTimeInSeconds { get { return Time.realtimeSinceStartup; } }
    }
}

