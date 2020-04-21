using ObjectPool;
using TankProject.Shells;
using UnityEngine;
using Zenject;

namespace TankProject.Weapon
{
    public sealed class TankCannon : WeaponBehaviour
    {
        [SerializeField] private TankShell shellPrefab;
        [SerializeField] private Transform launchPoint;

        private Pool<TankShell> _shellPool;

        [Inject]
        private void InstallBindings(Pool<TankShell> pool)
        {
            _shellPool = pool;
        }

        public override void Initialize()
        {
            State = WeaponState.Idle;
        }

        public override void Fire()
        {
            if (_shellPool == null || State != WeaponState.Idle) return;
            var shell = _shellPool.FromPool();
            shell.Enable(launchPoint.position, launchPoint.rotation);
            State = WeaponState.Reloading;
        }
    }
}
