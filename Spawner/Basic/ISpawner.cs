using System;

public interface ISpawner<T> : IDisposable
{
    T Spawn();
}
