using ObjectPool;
using TankProject.Units;
using UnityEngine;
using Zenject;

namespace TankProject.Spawners
{
    public sealed class HeavyTankSpawner : SpawnerBase
    {
        [SerializeField] private Transform spawnPoint;

        private Pool<HeavyTank> _tankPool;

        [Inject]
        private void InstallBindings(Pool<HeavyTank> pool)
        {
            _tankPool = pool;
        }
        
        public override void Spawn()
        {
            var tank = _tankPool.FromPool();
            tank.Enable(spawnPoint.position, spawnPoint.rotation);
        }

        public override void DeleteAll()
        {
            _tankPool.ToPoolAll();
        }
    }
}
