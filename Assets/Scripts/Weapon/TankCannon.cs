using ObjectPool;
using TankProject.Pools;
using TankProject.Shells;
using UnityEngine;

namespace TankProject.Weapon
{
    public sealed class TankCannon : WeaponBehaviour
    {
        [SerializeField] private TankShell shellPrefab;
        [SerializeField] private Transform launchPoint;

        private ShellPool _shellPool;

        public override void Initialize()
        {
            _shellPool = ShellPool.Create(shellPrefab, 10, "Tank Shells");
            State = WeaponState.Idle;
        }

        public override void Fire()
        {
            if (_shellPool == null || State != WeaponState.Idle) return;
            IPoolable<ShellBehaviour> shell = _shellPool.FromPool();
            shell.Enable(launchPoint.position, launchPoint.rotation);
            State = WeaponState.Reloading;
        }
    }
}
