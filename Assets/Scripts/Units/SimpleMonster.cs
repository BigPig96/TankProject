using ObjectPool;
using UnityEngine;

namespace TankProject.Units
{
    public class SimpleMonster : SeekerMonster, IPoolable<SimpleMonster>
    {
        public Pool<SimpleMonster> Pool { get; set; }

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