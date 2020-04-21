using ObjectPool;
using Tank.Factories;
using TankProject;
using TankProject.Shells;
using TankProject.Units;
using TankProject.Vfx;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private ExplosionData tankShellExplosionData;
    [SerializeField] private ExplosionData heavyTankExplosionData;
    [SerializeField] private ExplosionData bomberMonsterExplosionData;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<StandloneStartInput>().AsSingle();

        BindSinglePool<HeavyTank>(1, "Tanks/HeavyTank");
        BindSinglePool<SimpleMonster>(10, "Monsters/Monster1");
        BindSinglePool<TankMonster>(10, "Monsters/Monster2");
        BindSinglePool<BomberMonster>(10, "Monsters/Monster3");
        BindSinglePool<LaserShell>(10, "Shells/LaserShell");
        BindSinglePool<TankShell>(10, "Shells/TankShell");
        BindSinglePool<ExplosionEffect>(10, "Vfx/Explosion");

        Container.Bind<Explode>().AsCached().WithArguments(tankShellExplosionData).WhenInjectedInto<TankShell>();
        Container.Bind<Explode>().AsCached().WithArguments(heavyTankExplosionData).WhenInjectedInto<HeavyTank>();
        Container.Bind<Explode>().AsCached().WithArguments(bomberMonsterExplosionData).WhenInjectedInto<BomberMonster>();
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