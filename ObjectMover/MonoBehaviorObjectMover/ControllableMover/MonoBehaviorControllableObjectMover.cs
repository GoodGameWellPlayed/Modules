using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoBehaviorControllableObjectMover<A> : MonoBehaviorObjectMover, 
    IControllableObjectMover<A> where A : ControlArguments
{
    [SerializeField] MonoBehaviorMoveController _controller;

    public abstract bool Move(A arguments);

    public override void Move()
    {
        ControlArguments arguments = _controller.GetArguments();

        if (!(arguments is A) && (arguments != null))
        {
            Debug.LogError("Controller should return the other type of arguments");
        }

        if (!Move(arguments as A))
        {
            Stay();
        }
    }

    protected virtual void Stay() { }
}
