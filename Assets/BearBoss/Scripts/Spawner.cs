using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private string _name;
    private int _capacity;
    private List<GameObject> _templates;
    private ObjectPool _pool;

    public ObjectPool Initialize(ObjectPool pool, List<GameObject> templates, int capacity, string name)
    {
        ObjectPool objectPool = new ObjectPool();
        _templates = templates;
        _pool = objectPool.GetPool(pool, capacity, new GameObject(), name);
        foreach (var template in _templates)
        {
            _pool.Initialized(template);
        }
        return _pool;
    }

    public void Reset()
    {

    }
}
