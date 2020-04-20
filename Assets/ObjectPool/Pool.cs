using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public abstract class Pool<T> : MonoBehaviour where T : IPoolable<T>
    {
        private readonly Stack<T> _ready = new Stack<T>();
        private readonly Queue<T> _using = new Queue<T>();

        public T Prefab { get; private set; }
        
        private int _capacity;

        protected void Initialize(T prefab, int capacity)
        {
            Prefab = prefab;
            _capacity = capacity;
            
            Increase();
        }

        public void ToPool(T item)
        {
            _ready.Push(item);
        }

        public T FromPool()
        {
            if (_ready.Count == 0)
            {
                _using.Dequeue().Disable();
            }

            T item = _ready.Pop();
            _using.Enqueue(item);
            
            return item;
        }

        public void ToPoolAll()
        {
            while (_using.Count > 0)
            {
                _using.Dequeue().Disable();
            }
        }

        private void Increase()
        {
            for (int i = 0; i < _capacity; i++)
            {
                ToPool(Clone());
            }
        }

        protected abstract T Clone();
    }
}
