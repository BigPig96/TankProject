using ObjectPool;
using TankProject.Shells;
using UnityEngine;
using Zenject;

namespace TankProject.Weapon
{
    public sealed class LaserGun : WeaponBehaviour
    {
        [SerializeField] private Transform launchPoint;

        private Pool<LaserShell> _shellPool;

        [Inject]
        private void InstallBindings(Pool<LaserShell> pool)
        {
            _shellPool = pool;
        }

        protected override void Launch()
        {
            var laser = _shellPool.FromPool();
            laser.Enable(launchPoint.position, launchPoint.rotation);
        }
    }
}
