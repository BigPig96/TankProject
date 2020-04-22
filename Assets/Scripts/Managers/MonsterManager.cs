using System;
using TankProject.Spawners;
using TankProject.Units;
using Zenject;
using Random = UnityEngine.Random;

namespace TankProject.Managers
{
    public sealed class MonsterManager : IInitializable, IDisposable
    {
        public static int MonstersKilled { get; private set; }

        private readonly int _monstersOnScene;
        private readonly SpawnerBase[] _spawners;

        public MonsterManager(int monstersOnScene, MonsterSpawner<SimpleMonster> simpleMonster,
            MonsterSpawner<TankMonster> tankMonster, MonsterSpawner<BomberMonster> bomberMonster)
        {
            _monstersOnScene = monstersOnScene;
            _spawners = new SpawnerBase[3];
            _spawners[0] = simpleMonster;
            _spawners[1] = tankMonster;
            _spawners[2] = bomberMonster;
        }
        
        public void Initialize()
        {
            MonsterBehaviour.OnMonsterDie += OnMonsterDie;
            GameManager.OnGameStart += OnGameStarted;
        }

        public void Dispose()
        {
            MonsterBehaviour.OnMonsterDie -= OnMonsterDie;
            GameManager.OnGameStart -= OnGameStarted;
        }

        private void OnGameStarted()
        {
            DeleteAllMonsters();

            StartSpawn();
        }

        private void OnMonsterDie(MonsterBehaviour monster)
        {
            MonstersKilled++;
            SpawnRandomMonster();
        }

        private void StartSpawn()
        {
            for (int i = 0; i < _monstersOnScene; i++)
            {
                SpawnRandomMonster();
            }
        }

        private void SpawnRandomMonster()
        {
            int randomIndex = Random.Range(0, _spawners.Length);
            _spawners[randomIndex].Spawn();
        }

        private void DeleteAllMonsters()
        {
            foreach (var spawner in _spawners)
            {
                spawner.DeleteAll();
            }
        }
    }
}
