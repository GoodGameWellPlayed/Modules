using UnityEngine;

namespace Components.Timer
{
    public class DefaultTimeGetter : ITimeGetter
    {
        public float GetTimeInSeconds { get { return Time.realtimeSinceStartup; } }
    }
}

