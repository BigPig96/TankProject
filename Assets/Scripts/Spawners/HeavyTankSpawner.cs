using TankProject.Pools;
using TankProject.Units;
using UnityEngine;

namespace TankProject.Spawners
{
    public sealed class HeavyTankSpawner : MonoBehaviour
    {
        [SerializeField] private HeavyTank tankPrefab;
        [SerializeField] private Transform spawnPoint;

        private UnitPool _tankPool;

        private void Awake()
        {
            _tankPool = UnitPool.Create(tankPrefab, 1, "TankPool");
        }

        public UnitBehaviour SpawnTank()
        {
            var tank = _tankPool.FromPool();
            tank.Enable(spawnPoint.position, spawnPoint.rotation);
            return tank;
        }
    }
}
