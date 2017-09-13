public interface IPoolableObjectGetter<P, I> where P : IPoolableObject
{
    P GetPoolableObject(I objectIdentity);
}
