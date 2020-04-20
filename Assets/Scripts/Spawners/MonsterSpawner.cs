using ObjectPool;
using TankProject.Pools;
using TankProject.Units;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TankProject.Spawners
{
    public sealed class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] private MonsterBehaviour monsterPrefab;
        [SerializeField] private Transform[] spawnPoints;
        
        private int _lastSpawnPointIndex;
        private UnitPool _pool;

        private void Awake()
        {
            _pool = UnitPool.Create(monsterPrefab, 10, "Monsters");
        }

        public void SpawnRandom()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            if (randomIndex == _lastSpawnPointIndex) randomIndex++;
            if (randomIndex >= spawnPoints.Length) randomIndex -= spawnPoints.Length;
            _lastSpawnPointIndex = randomIndex;

            IPoolable<UnitBehaviour> monster = _pool.FromPool();
            var spawnPoint = spawnPoints[randomIndex];
            monster.Enable(spawnPoint.position, spawnPoint.rotation);
        }

        public void DeleteMonsters()
        {
            _pool.ToPoolAll();
        }
    }
}
