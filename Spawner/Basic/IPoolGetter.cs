public interface IPoolGetter<P, A> where P : IPoolableObject
{
    I GetPool<I>(A arguments) where I : IPool<P>;
}
