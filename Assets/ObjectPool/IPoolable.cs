using UnityEngine;

namespace ObjectPool
{
    public interface IPoolable<T> where T : IPoolable<T>
    {
        Pool<T> Pool { get; set; }
        void Enable(Vector2 position, Quaternion rotation);
        void Disable();
    }
}