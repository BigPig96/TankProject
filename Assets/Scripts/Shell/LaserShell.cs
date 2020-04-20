using UnityEngine;

namespace TankProject.Shells
{
    public sealed class LaserShell : ShellBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private LayerMask damageMask;
        
        private SpriteRenderer _renderer;

        protected override void Awake()
        {
            base.Awake();

            _renderer = GetComponent<SpriteRenderer>();
        }

        public override void Enable(Vector2 position, Quaternion rotation)
        {
            base.Enable(position, rotation);

            RBody.velocity = transform.up * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var unit = other.GetComponent<IDamagable>();
            if ((1 << other.gameObject.layer & damageMask) != 0)
                unit?.TakeDamage(damage);
            Disable();
        }
    }
}
