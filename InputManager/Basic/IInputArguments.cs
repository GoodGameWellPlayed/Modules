using System;
using UnityEngine;

public interface IInputArguments
{
}

public interface IPositionInputArguments : IInputArguments
{
    Vector3 Position { get; set; }
}

public interface IDurationInputArguments : IInputArguments
{
    float Duration { get; set; }
}

public class EmptyInputArguments : IInputArguments
{

}

public class DurationInputArguments : IDurationInputArguments
{
    public float Duration { get; set; }
}

public class PositionInputArguments : IPositionInputArguments
{
    public Vector3 Position { get; set; }
}

public class PositionDurationInputArguments : IDurationInputArguments, IPositionInputArguments
{
    public float Duration { get;  set; }
    public Vector3 Position { get; set; }
}

