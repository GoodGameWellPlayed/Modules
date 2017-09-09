using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControllableMover :
    MonoBehaviorControllableObjectMover<DirectionControlArguments>
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;

    public override bool Move(DirectionControlArguments arguments)
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        if (arguments == null || arguments.IsEmpty)
        {
            _rigidbody.velocity = Vector3.zero;
            return false;
        }

        _rigidbody.velocity = arguments.Direction * _speed;
        //transform.LookAt(transform.position + _rigidbody.velocity, Vector3.);
        //transform.localRotation = Quaternion.Euler(_rigidbody.velocity);
        return true;
    }
}
