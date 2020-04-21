using Lib;
using ObjectPool;
using UnityEngine;

namespace TankProject.Shells
{
    public sealed class TankShell : ShellBehaviour
    {
        [SerializeField] private ExplosionData explosion;
        [SerializeField] private float reloadingTime;

        public float LesionRadius => explosion.lesionRadius;

        private Explode _explode;

        protected override void Awake()
        {
            base.Awake();

            _explode = new Explode(explosion);
        }

        public override void Enable(Vector2 position, Quaternion rotation)
        {
            base.Enable(position, rotation);

            RBody.velocity = transform.up * speed;
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
