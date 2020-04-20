using System;
using TankProject.Managers;
using UnityEngine;

namespace TankProject.Units
{
    public abstract class MonsterBehaviour : AliveUnitBehaviour
    {
        public static event Action<MonsterBehaviour> OnMonsterDie;
        
        [SerializeField] protected LayerMask victimMask;

        protected IDamagable HitUnit;

        private Rigidbody2D _rb;

        protected override void Awake()
        {
            base.Awake();

            _rb = GetComponent<Rigidbody2D>();
        }

        protected abstract void Attack();

        private void OnCollisionEnter2D(Collision2D other)
        {
            var unit = other.collider.GetComponent<IDamagable>();
            if (unit == null || (1 << other.gameObject.layer & victimMask) == 0) return;
            HitUnit = unit;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            var unit = other.collider.GetComponent<IDamagable>();
            if (HitUnit == unit) HitUnit = null;
        }

        public override void Enable(Vector2 position, Quaternion rotation)
        {
            base.Enable(position, rotation);
            
            ChangeBodyType(RigidbodyType2D.Kinematic);
        }

        protected override void OnDie()
        {
            OnMonsterDie?.Invoke(this);
            base.OnDie();
        }

        public void ChangeBodyType(RigidbodyType2D type)
        {
            _rb.bodyType = type;
        }
    }
}
