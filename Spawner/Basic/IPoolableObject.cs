using UnityEngine;
using System.Collections;

public interface IPoolableObject
{
    void Destroy();
    void OnAfterSpawn();
    void OnBeforeDespawn();
    void OnSpawnerUpdate();
    void Despawn();
}