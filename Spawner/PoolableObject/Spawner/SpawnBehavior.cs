using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO in editor
[Serializable]
public abstract class SpawnBehavior<T, A> : MonoBehaviour where T : PoolableObjectArguments
    where A : IEnumerable<T>
{
    public abstract void GetPoolableArguments(A arguments);
}
