using System;

public interface IPool<T> : IDisposable
{
    T GetFromPool();
    void ReturnToPool(T poolableObject);
}
