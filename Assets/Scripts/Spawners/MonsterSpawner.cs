using ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TankProject.Spawners
{
    public sealed class MonsterSpawner<T> : SpawnerBase where T : ObjectPool.IPoolable<T>
    {
        private readonly Transform[] _spawnPoints;
        private readonly Pool<T> _pool;
        
        public MonsterSpawner(Pool<T> pool, Transform[] spawnPoints)
        {
            _pool = pool;
            _spawnPoints = spawnPoints;
        }

        public override void Spawn()
        {
            int randomIndex = Random.Range(0, _spawnPoints.Length);

            var monster = _pool.FromPool();
            var spawnPoint = _spawnPoints[randomIndex];
            monster.Enable(spawnPoint.position, spawnPoint.rotation);
        }

        public override void DeleteAll()
        {
            _pool.ToPoolAll();
        }
    }
}
