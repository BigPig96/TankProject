using ObjectPool;
using UnityEngine;
using Zenject;

namespace TankProject.Units
{
    public sealed class BomberMonster : SeekerMonster, ObjectPool.IPoolable<BomberMonster>
    {
        public Pool<BomberMonster> Pool { get; set; }

        [SerializeField] private float selfDamage;
        
        private Explode _explode;
        private Vector2 _diePosition;

        [Inject]
        private void InstallBindings(Explode explode)
        {
            _explode = explode;
        }

        protected override void OnAttack()
        {
            TakeDamage(selfDamage);
        }

        public override void Disable()
        {
            base.Disable();
            
            Pool?.ToPool(this);
        }

        protected override void OnDie()
        {
            _diePosition = transform.position;
            base.OnDie();
            
            Explode();
        }

        private void Explode()
        {
            _explode.Execute(_diePosition);
        }
    }
}
