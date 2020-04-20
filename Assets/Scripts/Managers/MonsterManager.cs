using Lib;
using TankProject.Spawners;
using TankProject.Units;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TankProject.Managers
{
    public sealed class MonsterManager : MonoBehaviour
    {
        public static MonsterManager Instance { get; private set; }

        public int KilledCount { get; private set; }

        [SerializeField] private int monstersOnScene;
        [SerializeField] private MonsterSpawner[] monsterSpawners;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void OnEnable()
        {
            MonsterBehaviour.OnMonsterDie += OnMonsterDie;
            GameManager.OnGameStart += OnGameStarted;
        }

        private void OnDisable()
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
            SpawnRandomMonster();
            KilledCount++;
        }

        private void StartSpawn()
        {
            for (int i = 0; i < monstersOnScene; i++)
            {
                SpawnRandomMonster();
            }
        }

        private void SpawnRandomMonster()
        {
            int randomIndex = Random.Range(0, monsterSpawners.Length);
            monsterSpawners[randomIndex].SpawnRandom();
        }

        private void DeleteAllMonsters()
        {
            foreach (var monsterSpawner in monsterSpawners)
            {
                monsterSpawner.DeleteMonsters();
            }
        }
    }
}
