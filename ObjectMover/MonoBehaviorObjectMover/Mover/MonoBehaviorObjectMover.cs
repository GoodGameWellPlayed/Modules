using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoBehaviorObjectMover : MonoBehaviour, IObjectMover
{
    public abstract void Move();

    void Update ()
    {
        Move();
    }
}
