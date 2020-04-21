using ObjectPool;
using UnityEngine;
using Zenject;

namespace TankProject.Units
{
    public sealed class BomberMonster : SeekerMonster, ObjectPool.IPoolable<BomberMonster>
    {
        public Pool<BomberMonster> Pool { get; set; }

        private Explode _explode;
        private bool _isExploded;

        [Inject]
        private void InstallBindings(Explode explode)
        {
            _explode = explode;
        }

        public override void Enable(Vector2 position, Quaternion rotation)
        {
            base.Enable(position, rotation);
            
            _isExploded = false;
        }

        protected override void OnAttack()
        {
            if(!_isExploded)
                OnDie();
        }

        public override void Disable()
        {
            base.Disable();
            
            Pool?.ToPool(this);
        }

        protected override void OnDie()
        {
            base.OnDie();
            
            Explode();
        }

        private void Explode()
        {
            _isExploded = true;
            Vector2 position = transform.position;
            _explode.Execute(position);
        }
    }
}
