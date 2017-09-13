using System.Collections.Generic;

public interface IPoolGroup<P> where P : IPoolableObject
{
    void Destroy();
    string Name { get; }
    List<IPool<P>> Pools { get; }
}