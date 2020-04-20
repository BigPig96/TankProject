using ObjectPool;
using TankProject.Vfx;
using UnityEngine;

namespace TankProject.Pools
{
    public sealed class VfxPool : Pool<VfxBehaviour>
    {
        public static VfxPool Create(VfxBehaviour prefab, int capacity, string poolName = "Pool")
        {
            var obj = new GameObject(poolName);
            var pool = obj.AddComponent<VfxPool>();
            pool.Initialize(prefab, capacity);

            return pool;
        }

        protected override VfxBehaviour Clone()
        {
            var clone = Instantiate(Prefab, transform);
            clone.Pool = this;
            clone.gameObject.SetActive(false);

            return clone;
        }
    }
}
