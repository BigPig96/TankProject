using UnityEngine;

namespace TankProject.Units
{
    public abstract class SeekerMonster : MonsterBehaviour
    {
        [SerializeField] protected float attackDelay;
        
        private float _attackTimer;

        protected override void Update()
        {
            base.Update();
            
            AttackProcess();
        }

        protected abstract void OnAttack();

        private void AttackProcess()
        {
            if (HitUnit == null) return;
            _attackTimer += Time.deltaTime;
            if (!(_attackTimer > attackDelay)) return;
            _attackTimer = 0;
            OnAttack();
        }
    }
}
