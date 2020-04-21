using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Pool<T> where T : IPoolable<T>
    {
        private readonly Stack<IPoolable<T>> _ready = new Stack<IPoolable<T>>();
        private readonly List<IPoolable<T>> _using = new List<IPoolable<T>>();

        private readonly T _prefab;
        private readonly int _capacity;
        private readonly Transform _holder;

        private Pool(T prefab, int capacity, Transform holder)
        {
            _prefab = prefab;
            _capacity = capacity;
            _holder = holder;
        }

        public static Pool<T> Create(T prefab, int capacity, string holderName = "Pool")
        {
            var obj = new GameObject(holderName);
            var pool = new Pool<T>(prefab, capacity, obj.transform);
            pool.Increase();
            return pool;
        }

        public void ToPool(IPoolable<T> item)
        {
            if(!_ready.Contains(item)) _ready.Push(item);
            if (_using.Contains(item)) _using.Remove(item);
        }

        public IPoolable<T> FromPool()
        {
            if (_ready.Count == 0)
            {
                _using[0].Disable();
            }

            var item = _ready.Pop();
            _using.Add(item);
            
            return item;
        }

        public void ToPoolAll()
        {
            while (_using.Count != 0)
            {
                _using[0].Disable();
            }
        }

        private void Increase()
        {
            for (int i = 0; i < _capacity; i++)
            {
                Clone();
            }
        }

        private void Clone()
        {
            var obj = Object.Instantiate(_prefab as Object, _holder);
            var clone = (IPoolable<T>) obj;
            clone.Pool = this;
            clone.Disable();
        }
    }
}
