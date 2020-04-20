using ObjectPool;
using TankProject.Units;
using UnityEngine;

namespace TankProject.Pools
{
    public sealed class UnitPool : Pool<UnitBehaviour>
    {
        public static UnitPool Create(UnitBehaviour prefab, int capacity, string poolName = "Pool")
        {
            var obj = new GameObject(poolName);
            var pool = obj.AddComponent<UnitPool>();
            pool.Initialize(prefab, capacity);

            return pool;
        }

        protected override UnitBehaviour Clone()
        {
            var clone = Instantiate(Prefab, transform);
            clone.Pool = this;
            clone.gameObject.SetActive(false);

            return clone;
        }
    }
}
