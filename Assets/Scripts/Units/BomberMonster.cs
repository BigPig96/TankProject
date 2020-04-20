using System.Collections;
using System.Collections.Generic;
using ObjectPool;
using TankProject;
using TankProject.Vfx;
using UnityEngine;

namespace TankProject.Units
{
    public sealed class BomberMonster : MonsterBehaviour
    {
        [SerializeField] private float attackDelay;
        [SerializeField] private ExplosionData explosion;
        public float LesionRadius => explosion.lesionRadius;

        private Explode _explode;
        private bool _isExploded;
        private float _attackTimer;

        protected override void Awake()
        {
            base.Awake();
            
            _explode = new Explode(explosion);
        }

        private void Update()
        {
            Process();
        }

        public override void Enable(Vector2 position, Quaternion rotation)
        {
            base.Enable(position, rotation);
            
            _isExploded = false;
        }

        protected override void OnDie()
        {
            base.OnDie();
            
            Explode();
        }

        private void Process()
        {
            Move();
            Attack();
        }

        protected override void Attack()
        {
            if(HitUnit == null || _isExploded) return;
            _attackTimer += Time.deltaTime;
            if (!(_attackTimer > attackDelay)) return;
            _attackTimer = 0;
            OnDie();
        }

        private void Explode()
        {
            _isExploded = true;
            Vector2 position = transform.position;
            _explode.Execute(position);
        }
    }
}
