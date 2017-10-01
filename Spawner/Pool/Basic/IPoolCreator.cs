public interface IPoolCreator
{
    IPool<T> CreatePool<T>(T prefab);
}
