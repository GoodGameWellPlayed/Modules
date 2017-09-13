public class PrefabPoolDictionary : PoolsDictionary<PoolableObject>
{
    protected override IPool<PoolableObject> CreatePool(PoolableObject poolableObjectPrefab)
    {
        return new PrefabPool<PoolableObject>(poolableObjectPrefab);
    }
}
