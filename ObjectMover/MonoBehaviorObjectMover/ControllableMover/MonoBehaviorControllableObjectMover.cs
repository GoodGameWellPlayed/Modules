using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoBehaviorControllableObjectMover<A> : MonoBehaviorObjectMover, 
    IControllableObjectMover<A> where A : IControlArguments
{
    [SerializeField] MonoBehaviorMoveController _controller;

    public abstract bool Move(A arguments);

    public override void Move()
    {
        IControlArguments arguments = _controller.GetArguments();

        if (!(arguments is A) && (arguments != null))
        {
            Debug.LogError("Controller should return the other type of arguments");
        }

        if (!Move((A)arguments))
        {
            Stay();
        }
    }

    protected virtual void Stay() { }
}
