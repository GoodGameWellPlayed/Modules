using System.Collections.Generic;
using UnityEngine;

public class PoolGroupDictionary: Dictionary<string, IPoolGroup<PoolableObject>>
{
    public bool Destroy(string groupName)
    {
        IPoolGroup<PoolableObject> poolGroup;
		if (!TryGetValue(groupName, out poolGroup))
		{
			return false;
		}
		poolGroup.Destroy();
		Remove(groupName);
		return true;
    }

    public void Destroy(IPoolGroup<PoolableObject> poolGroup)
    {
		Destroy (poolGroup.Name);
    }

	public void DestroyAll()
	{
		foreach (var kv in this)
        {
			kv.Value.Destroy();
        }
		this.Clear ();
	}
}

