using TankProject;
using TankProject.Shells;
using TankProject.Units;
using UnityEngine;
using Zenject;

namespace TankProject.Installers
{
    public class ExplodeInstaller : MonoInstaller
    {
        [SerializeField] private ExplosionData tankShellExplosionData;
        [SerializeField] private ExplosionData heavyTankExplosionData;
        [SerializeField] private ExplosionData bomberMonsterExplosionData;

        public override void InstallBindings()
        {
            Container.Bind<Explode>().AsCached().WithArguments(tankShellExplosionData).WhenInjectedInto<TankShell>();
            Container.Bind<Explode>().AsCached().WithArguments(heavyTankExplosionData).WhenInjectedInto<HeavyTank>();
            Container.Bind<Explode>().AsCached().WithArguments(bomberMonsterExplosionData)
                .WhenInjectedInto<BomberMonster>();
        }
    }
}