using ObjectPool;
using UnityEngine;
using Zenject;

namespace TankProject.Shell
{
    public sealed class TankShell : ShellBehaviour, ObjectPool.IPoolable<TankShell>
    {
        public Pool<TankShell> Pool { get; set; }

        private Explode _explode;

        [Inject]
        private void InstallBindings(Explode explode)
        {
            _explode = explode;
        }
        
        public override void Enable(Vector2 position, Quaternion rotation)
        {
            base.Enable(position, rotation);

            RBody.velocity = transform.up * speed;
        }

        public override void Disable()
        {
            base.Disable();
            
            Pool?.ToPool(this);
        }

        protected override void Destruct()
        {
            Explode();

            base.Destruct();
        }

        private void Explode()
        {
            Vector2 position = transform.position;
            _explode.Execute(position);
        }
    }
}
