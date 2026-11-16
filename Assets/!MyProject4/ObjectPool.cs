using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private readonly T _prefab;
    private readonly Transform _parent;
    private readonly Stack<T> _pool = new();
    private readonly int _maxSize;

    public ObjectPool(T prefab, int initialSize = 10, int maxSize = 100, Transform parent = null)
    {
        _prefab = prefab;
        _maxSize = maxSize;
        _parent = parent;
        for (int i = 0; i < initialSize; i++)
        {
            var objects = Object.Instantiate<T>(_prefab, _parent);
            objects.gameObject.SetActive(false);
            _pool.Push(objects);
        }
    }

    public T Get()
    {
        T objects = _pool.Count > 0
            ? _pool.Pop()
            : Object.Instantiate<T>(_prefab, _parent);
        objects.gameObject.SetActive(true);
        return objects;
    }

    public void Return(T objects)
    {
        if (objects == null) return;
        objects.gameObject.SetActive(false);
        if (_pool.Count < _maxSize)
            _pool.Push(objects);
        else
            Object.Destroy(objects.gameObject);
    }
}