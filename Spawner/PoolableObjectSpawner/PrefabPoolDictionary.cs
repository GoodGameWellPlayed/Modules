public class PrefabPoolDictionary : PoolsDictionary<PoolableObject, PoolableObjectPrefabPool>
{
    private static PrefabPoolDictionary _instance;

    public static PrefabPoolDictionary Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PrefabPoolDictionary();
            }
            return _instance;
        }
    }

    protected override PoolableObjectPrefabPool CreatePool(PoolableObject poolableObjectPrefab)
    {
        return new PoolableObjectPrefabPool(poolableObjectPrefab);
    }
}
