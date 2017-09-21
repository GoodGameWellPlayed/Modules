public interface IPoolableObjectGetter<I>
{
    PoolableObject GetPoolableObject(I objectIdentity);

    PoolableObject GetRandomPoolableObject();
}
