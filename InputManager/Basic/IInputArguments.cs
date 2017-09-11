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

public interface IDirectionInputArguments : IInputArguments
{
    Vector3 Direction { get; set; }
}

public class EmptyInputArguments : IInputArguments
{

}

