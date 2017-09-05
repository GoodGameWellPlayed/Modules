using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class PrefabPool : IPool<PoolableObject>
{
	public string Name;
	public PoolableObject Prefab;
	public int PoolSize = 1;
	public bool Extendable;
		
	protected Queue<PoolableObject> ready;
	protected List<PoolableObject> pooled;

    bool inited = false;
    public bool Inited
    {
        get
        {
            return inited;
        }
    }

	public PoolableObject[] Pooled
	{
		get
		{
			return pooled.ToArray();
		}
	}

    public PoolableObject[] Ready
    {
        get
        {
            return ready.ToArray();
        }
    }

    public PrefabPool(PoolableObject poolableObject, bool extendable = true)
	{
		ready = new Queue<PoolableObject>();
		pooled = new List<PoolableObject>();
        Prefab = poolableObject;
        Extendable = extendable;
        Init();
    }

    public virtual void InitSpawner()
    {
    }

    public void Init()
    {
        PoolableObject script;
        GameObject instance;
        InitSpawner();
        for (int i = 0; i < PoolSize; i++)
        {
            instance = Object.Instantiate(Prefab.gameObject) as GameObject;
            script = instance.GetComponent<PoolableObject>();
            if (script==null)
            {
                script=instance.AddComponent<PoolableObject>();
            }
            script.Pool = this;
            ready.Enqueue(script);
            instance.SetActive(false);
        }
        inited = true;
    }
        
	public virtual PoolableObject Spawn()
	{
		if (ready.Count==0)
		{
			if (Extendable)
			{
                PoolableObject temp = (UnityEngine.Object.Instantiate(Prefab.gameObject) 
                    as GameObject).GetComponent<PoolableObject>();
                temp.Pool = this;
                ready.Enqueue(temp);
			}
            else
			{
				return null;
			}
		}

        PoolableObject obj = ready.Dequeue();
		obj.gameObject.SetActive(true);
        obj.OnAfterSpawn();
		pooled.Add(obj);
		return obj;
	}

		
	public virtual void Despawn(PoolableObject pobj)
	{
        ready.Enqueue(pobj);
        pooled.Remove(pobj);
        pobj.OnBeforeDespawn();
        pobj.gameObject.SetActive(false);
	}
		
	public void Destroy()
	{
		while (ready.Count > 0)
		{
			ready.Dequeue().Destroy();
		}
		for (int i = 0; i < pooled.Count; i++)
		{
			pooled[i].Destroy();
		}
		ready.Clear();
        pooled.Clear();
        inited = false;
	}
}

