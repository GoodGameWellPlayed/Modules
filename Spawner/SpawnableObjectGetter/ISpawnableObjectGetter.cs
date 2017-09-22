public interface ISpawnableObjectGetter<I>
{
    ISpawnableObject GetSpawnableObject(I objectIdentity);

    ISpawnableObject GetRandomSpawnableObject();
}
