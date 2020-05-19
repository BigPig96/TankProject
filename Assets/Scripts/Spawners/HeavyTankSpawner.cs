using ObjectPool;
using TankProject.Units;
using UnityEngine;

namespace TankProject.Spawners
{
    public sealed class HeavyTankSpawner : SpawnerBase
    {
        private readonly Transform _spawnPoint;
        private readonly Pool<HeavyTank> _tankPool;
        
        public HeavyTankSpawner(Pool<HeavyTank> pool, Transform spawnPoint)
        {
            _tankPool = pool;
            _spawnPoint = spawnPoint;
        }
        
        public override void Spawn()
        {
            var tank = _tankPool.FromPool();
            tank.Enable(_spawnPoint.position, _spawnPoint.rotation);
        }

        public override void DeleteAll()
        {
            _tankPool.ToPoolAll();
        }
    }
}
