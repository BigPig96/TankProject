using ObjectPool;
using TankProject.Shells;
using UnityEngine;

namespace TankProject.Pools
{
    public sealed class ShellPool : Pool<ShellBehaviour>
    {
        public static ShellPool Create(ShellBehaviour prefab, int capacity, string poolName = "Pool")
        {
            var obj = new GameObject(poolName);
            var pool = obj.AddComponent<ShellPool>();
            pool.Initialize(prefab, capacity);

            return pool;
        }

        protected override ShellBehaviour Clone()
        {
            var clone = Instantiate(Prefab, transform);
            clone.Pool = this;
            clone.gameObject.SetActive(false);

            return clone;
        }
    }
}
