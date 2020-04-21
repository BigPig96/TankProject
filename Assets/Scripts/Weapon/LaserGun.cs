using ObjectPool;
using TankProject.Shells;
using UnityEngine;
using Zenject;

namespace TankProject.Weapon
{
    public sealed class LaserGun : WeaponBehaviour
    {
        [SerializeField] private LaserShell laserPrefab;
        [SerializeField] private Transform launchPoint;

        private Pool<LaserShell> _shellPool;

        [Inject]
        private void InstallBindings(Pool<LaserShell> pool)
        {
            _shellPool = pool;
        }

        public override void Initialize()
        {
            State = WeaponState.Idle;
        }

        public override void Fire()
        {
            if (_shellPool == null || State == WeaponState.Reloading) return;
            var laser = _shellPool.FromPool();
            laser.Enable(launchPoint.position, launchPoint.rotation);
            State = WeaponState.Reloading;
        }
    }
}
