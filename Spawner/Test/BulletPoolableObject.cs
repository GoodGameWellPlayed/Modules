using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolableObject : PoolableObject
{
    [SerializeField] private float _force;

    public override void OnAfterSpawn()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 0) * _force);
    }
}
