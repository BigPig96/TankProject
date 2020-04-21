using ObjectPool;
using UnityEngine;

namespace TankProject.Units
{
    public sealed class TankMonster : SeekerMonster, IPoolable<TankMonster>
    { 
        public Pool<TankMonster> Pool { get; set; }

        [SerializeField] private float damage;

        protected override void OnAttack()
        {
            HitUnit.TakeDamage(damage);
        }

        public override void Disable()
        {
            base.Disable();
            
            Pool?.ToPool(this);
        }
    }
}
