using TankProject.Spawners;
using TankProject.Units;
using UnityEngine;
using Zenject;

namespace TankProject.Installers
{
    public class SpawnerInstaller : MonoInstaller
    {
        [SerializeField] private Transform tankSpawnPoint;
        [SerializeField] private Transform[] simpleMonsterSpawnPoints;
        [SerializeField] private Transform[] tankMonsterSpawnPoints;
        [SerializeField] private Transform[] bomberMonsterSpawnPoints;

        public override void InstallBindings()
        {
            Container.Bind<HeavyTankSpawner>().AsSingle()
                .WithArguments(tankSpawnPoint);
            Container.Bind<MonsterSpawner<SimpleMonster>>().AsSingle()
                .WithArguments(simpleMonsterSpawnPoints);
            Container.Bind<MonsterSpawner<TankMonster>>().AsSingle()
                .WithArguments(tankMonsterSpawnPoints);
            Container.Bind<MonsterSpawner<BomberMonster>>().AsSingle()
                .WithArguments(bomberMonsterSpawnPoints);
        }
    }
}