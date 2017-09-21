public class PoolableObjectPrefabPool : PrefabPool<PoolableObject>
{
    public PoolableObjectPrefabPool(PoolableObject poolableObject, bool isExtendable = true) 
        : base(poolableObject, isExtendable)
    {
    }

    protected override PoolableObject InstantiateObject()
    {
        return Prefab.InstantiateObject(this);
    }
}
