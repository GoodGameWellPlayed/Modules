using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectDependantControllableObjectMover<A, T> : ObjectDependantObjectMover<T>, 
    IControllableObjectMover<A> where A : ControlArguments where T : MonoBehaviour
{
    protected abstract IMoveController Controller { get; }

    public abstract bool Move(A arguments);

    public override void Move()
    {
        ControlArguments arguments = Controller.GetArguments();

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
