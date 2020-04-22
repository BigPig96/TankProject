using System.Collections.Generic;
using Zenject;

namespace ObjectPool
{
    public sealed class Pool<T> where T : IPoolable<T>
    {
        private readonly Stack<IPoolable<T>> _ready = new Stack<IPoolable<T>>();
        private readonly List<IPoolable<T>> _using = new List<IPoolable<T>>();

        private readonly IFactory<T> _factory;
        private readonly int _capacity;

        private Pool(IFactory<T> factory, int capacity)
        {
            _factory = factory;
            _capacity = capacity;

            Increase();
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
            var clone = _factory.Create();
            clone.Pool = this;
            clone.Disable();
        }
    }
}
