using ObjectPool;
using UnityEngine;

namespace TankProject.Shells
{
    public sealed class LaserShell : ShellBehaviour, IPoolable<LaserShell>
    {
        public Pool<LaserShell> Pool { get; set; }

        [SerializeField] private float damage;
        [SerializeField] private LayerMask damageMask;
        
        public override void Enable(Vector2 position, Quaternion rotation)
        {
            base.Enable(position, rotation);

            RBody.velocity = transform.up * speed;
        }

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            var unit = other.gameObject.GetComponent<IDamagable>();
            if ((1 << other.gameObject.layer & damageMask) != 0)
                unit?.TakeDamage(damage);
            
            base.OnCollisionEnter2D(other);
        }

        public override void Disable()
        {
            base.Disable();
            Pool?.ToPool(this);
        }
    }
}
