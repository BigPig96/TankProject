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
        private readonly Pool<ExplosionEffect> _pool;

        public Explode(ExplosionData data, Pool<ExplosionEffect> pool)
        {
            _damage = data.damage;
            _lesionRadius = data.lesionRadius;
            _targets = new Collider2D[data.maxTargets];
            _damageMask = data.targetsMask;

            _pool = pool;
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
            
            var effect = _pool.FromPool();
            effect.Enable(position, Quaternion.identity);
        }
    }
}
