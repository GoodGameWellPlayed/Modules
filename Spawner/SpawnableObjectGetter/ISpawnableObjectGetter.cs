public interface ISpawnableObjectGetter<I>
{
    ISpawnableObject GetSpawnableObject(I objectIdentity);

    ISpawnableObject GetRandomSpawnableObject();
}

public interface ISpawnableObjectGetter<I, T> where T : ISpawnableObject
{
    T GetSpawnableObject(I objectIdentity);

    T GetRandomSpawnableObject();
}

