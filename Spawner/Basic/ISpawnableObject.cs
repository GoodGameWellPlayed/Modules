using System;

public interface ISpawnableObject
{
    void OnAfterSpawn();
    void OnBeforeDespawn(Action<bool> despawnAction);
}
