using System;
using ObjectPool;
using TankProject.Shells;
using UnityEngine;

namespace TankProject.Weapon
{
    public sealed class LaserGun : WeaponBehaviour
    {
        [SerializeField] private LaserShell laserPrefab;
        [SerializeField] private Transform launchPoint;

        private Pool<ShellBehaviour> _shellPool;

        public override void Initialize()
        {
            _shellPool = Pool<ShellBehaviour>.Create(laserPrefab, 10, "Lasers");
            State = WeaponState.Idle;
        }

        public override void Fire()
        {
            if (_shellPool == null || State == WeaponState.Reloading) return;
            IPoolable<ShellBehaviour> laser = _shellPool.FromPool();
            laser.Enable(launchPoint.position, launchPoint.rotation);
            State = WeaponState.Reloading;
        }
    }
}
