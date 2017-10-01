public class DefaultPoolCreator : IPoolCreator
{
    public IPool<T> CreatePool<T>(T prefab)
    {
        return new PrefabPool<T>(prefab);
    }
}
