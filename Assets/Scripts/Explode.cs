using System;
using ObjectPool;
using TankProject.Vfx;
using UnityEngine;

namespace TankProject
{
    public sealed class Explode
    {
        private readonly float _damage;
        private readonly float _lesionRadius;
        private readonly Collider2D[] _targets;
        private readonly LayerMask _damageMask;

        public Explode(ExplosionData data)
        {
            _damage = data.damage;
            _lesionRadius = data.lesionRadius;
            _targets = new Collider2D[data.maxTargets];
            _damageMask = data.targetsMask;
        }

        public void Execute(Vector2 position)
        {
            Array.Clear(_targets, 0, _targets.Length);

            Physics2D.OverlapCircleNonAlloc(position, _lesionRadius, _targets, _damageMask);

            foreach (var hit in _targets)
            {
                if (hit == null) continue;
                IDamagable damagable = hit.gameObject.GetComponent<IDamagable>();
                damagable?.TakeDamage(_damage);
            }
            
            IPoolable<VfxBehaviour> vfx = VfxManager.Instance.ExplosionEffectPool.FromPool();
            vfx.Enable(position, Quaternion.identity);
        }
    }
}
