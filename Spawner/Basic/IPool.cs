public interface IPool<P> where P : IPoolableObject
{
    P Spawn();
    void Despawn(P pobj);
    void Destroy();
    P[] Pooled { get; }
}

