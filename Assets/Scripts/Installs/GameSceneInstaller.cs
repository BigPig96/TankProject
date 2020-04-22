using ObjectPool;
using Tank.Factories;
using TankProject;
using TankProject.Managers;
using TankProject.Shells;
using TankProject.Spawners;
using TankProject.Units;
using TankProject.Vfx;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private ExplosionData tankShellExplosionData;
    [SerializeField] private ExplosionData heavyTankExplosionData;
    [SerializeField] private ExplosionData bomberMonsterExplosionData;

    [SerializeField] private int maxMonstersOnScene;
    
    [SerializeField] private Transform tankSpawnPoint;
    [SerializeField] private Transform[] simpleMonsterSpawnPoints;
    [SerializeField] private Transform[] tankMonsterSpawnPoints;
    [SerializeField] private Transform[] bomberMonsterSpawnPoints;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
        Container.BindInterfacesTo<StandloneStartInput>().AsSingle();
        Container.BindInterfacesAndSelfTo<TankManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<MonsterManager>().AsSingle()
            .WithArguments(maxMonstersOnScene);

        Container.Bind<HeavyTankSpawner>().AsSingle()
            .WithArguments(tankSpawnPoint);
        Container.Bind<MonsterSpawner<SimpleMonster>>().AsSingle()
            .WithArguments(simpleMonsterSpawnPoints);
        Container.Bind<MonsterSpawner<TankMonster>>().AsSingle()
            .WithArguments(tankMonsterSpawnPoints);
        Container.Bind<MonsterSpawner<BomberMonster>>().AsSingle()
            .WithArguments(bomberMonsterSpawnPoints);
        
        Container.Bind<Explode>().AsCached().WithArguments(tankShellExplosionData).WhenInjectedInto<TankShell>();
        Container.Bind<Explode>().AsCached().WithArguments(heavyTankExplosionData).WhenInjectedInto<HeavyTank>();
        Container.Bind<Explode>().AsCached().WithArguments(bomberMonsterExplosionData).WhenInjectedInto<BomberMonster>();

        BindSinglePool<HeavyTank>(1, "Tanks/HeavyTank");
        BindSinglePool<SimpleMonster>(10, "Monsters/Monster1");
        BindSinglePool<TankMonster>(10, "Monsters/Monster2");
        BindSinglePool<BomberMonster>(10, "Monsters/Monster3");
        BindSinglePool<LaserShell>(10, "Shells/LaserShell");
        BindSinglePool<TankShell>(10, "Shells/TankShell");
        BindSinglePool<ExplosionEffect>(10, "Vfx/Explosion");
    }

    private void BindSinglePool<T>(int capacity, string prefabPath) where T : ObjectPool.IPoolable<T>
    {
        Container.BindIFactory<string, T>().FromFactory<ResourcesPrefabFactory<T>>();
        Container.Bind<Pool<T>>()
            .AsSingle()
            .WithArguments(capacity, prefabPath)
            .NonLazy();
    }
}