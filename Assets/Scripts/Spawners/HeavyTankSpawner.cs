using ObjectPool;
using TankProject.Units;
using UnityEngine;

namespace TankProject.Spawners
{
    public sealed class HeavyTankSpawner : MonoBehaviour
    {
        [SerializeField] private HeavyTank tankPrefab;
        [SerializeField] private Transform spawnPoint;

        private Pool<UnitBehaviour> _tankPool;

        private void Awake()
        {
            _tankPool = Pool<UnitBehaviour>.Create(tankPrefab, 1, "TankPool");
        }

        public UnitBehaviour SpawnTank()
        {
            var tank = _tankPool.FromPool();
            tank.Enable(spawnPoint.position, spawnPoint.rotation);
            return (UnitBehaviour)tank;
        }
    }
}
