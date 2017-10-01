using System;

public interface IObjectPoolLibrary : IDisposable
{
    void AddDependency<T>(T poolableObject, IPool<T> pool);
    void RemoveDependency<T>(T poolableObject);
    IPool<T> GetPool<T>(T poolableObject);
}
