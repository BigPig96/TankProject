using ObjectPool;
using TankProject.Shells;
using TankProject.Units;
using TankProject.Vfx;
using Zenject;

namespace TankProject.Installers
{
    public class PoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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
            Container.BindIFactory<T>()
                .FromComponentInNewPrefabResource(prefabPath)
                .AsCached();
            Container.Bind<Pool<T>>()
                .AsSingle()
                .WithArguments(capacity, prefabPath)
                .NonLazy();
        }
    }
}