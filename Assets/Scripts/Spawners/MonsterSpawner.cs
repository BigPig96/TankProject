using ObjectPool;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace TankProject.Spawners
{
    public class MonsterSpawner<T> : SpawnerBase where T : ObjectPool.IPoolable<T>
    {
        [SerializeField] protected Transform[] _spawnPoints;
        
        private Pool<T> _pool;
        
        [Inject]
        public void InstallBindings(Pool<T> pool)
        {
            _pool = pool;
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
