using ObjectPool;
using TankProject.Shell;
using UnityEngine;
using Zenject;

namespace TankProject.Weapon
{
    public sealed class TankCannon : WeaponBehaviour
    {
        [SerializeField] private Transform launchPoint;

        private Pool<TankShell> _shellPool;

        [Inject]
        private void InstallBindings(Pool<TankShell> pool)
        {
            _shellPool = pool;
        }

        protected override void Launch()
        {
            var shell = _shellPool.FromPool();
            shell.Enable(launchPoint.position, launchPoint.rotation);
        }
    }
}
