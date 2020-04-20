using UnityEngine;
using UnityEngine.UI;

namespace TankProject.Units
{
    public sealed class SimpleMonster : MonsterBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float attackDelay;
        
        private float _attackTimer;

        private void Update()
        {
            Process();
        }

        private void Process()
        {
            Attack();
            Move();
        }

        protected override void Attack()
        {
            if (HitUnit == null) return;
            _attackTimer += Time.deltaTime;
            if (!(_attackTimer > attackDelay)) return;
            _attackTimer = 0;
            HitUnit.TakeDamage(damage);
        }
    }
}
