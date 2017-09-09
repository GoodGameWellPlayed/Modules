using System;
using UnityEngine;

public interface IPositionInputArguments
{
    Vector3 Position { get; set; }
}

public interface IDurationInputArguments
{
    float Duration { get; set; }
}

public class InputArguments
{
}

public class DurationInputArguments : InputArguments, IDurationInputArguments
{
    public float Duration { get; set; }
}

public class PositionDurationInputArguments : InputArguments, IDurationInputArguments, IPositionInputArguments
{
    public float Duration { get;  set; }
    public Vector3 Position { get; set; }
}

public class PositionInputArguments : InputArguments, IDurationInputArguments, IPositionInputArguments
{
    public float Duration { get; set; }
    public Vector3 Position { get; set; }
}

