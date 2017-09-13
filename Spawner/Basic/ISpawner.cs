using System.Collections.Generic;

public interface ISpawner<P> where P : IPoolableObject
{
    IEnumerable<P> Spawn();
}
