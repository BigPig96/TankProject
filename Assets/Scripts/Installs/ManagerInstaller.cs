using TankProject.Managers;
using UnityEngine;
using Zenject;

namespace TankProject.Installers
{
    public class ManagerInstaller : MonoInstaller
    {
        [SerializeField] private int maxMonstersOnScene;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
            Container.BindInterfacesTo<StandloneStartInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<TankManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<MonsterManager>().AsSingle()
                .WithArguments(maxMonstersOnScene);
        }
    }
}