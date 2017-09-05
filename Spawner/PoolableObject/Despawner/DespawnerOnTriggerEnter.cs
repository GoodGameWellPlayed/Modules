using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO from Conditional
public class DespawnerOnTriggerEnter : DespawnerConditional
{
    private void OnTriggerEnter(Collider other)
    {
        PoolableObject otherPO = other.GetComponent<PoolableObject>();
        if (otherPO != null)
        {
            AddToDespawnableArray(otherPO);
        }
    }
}
