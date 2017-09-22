using System;

public interface ISpawner<T> : IDisposable where T : ISpawnableObject
{
    T Spawn();
}
