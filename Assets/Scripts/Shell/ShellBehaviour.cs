using Lib;
using ObjectPool;
using UnityEngine;

namespace TankProject.Shells
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ShellBehaviour : MonoBehaviour, IPoolable<ShellBehaviour>
    {
        [SerializeField] protected float lifetime;
        [SerializeField] protected float speed;

        public Pool<ShellBehaviour> Pool { get; set; }

        protected Rigidbody2D RBody;

        private Wait _destruction;

        protected virtual void Awake()
        {
            RBody = GetComponent<Rigidbody2D>();
            _destruction = this.WaitForSeconds(lifetime, Disable);
        }

        public virtual void Enable(Vector2 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;

            gameObject.SetActive(true);

            _destruction.Start();
        }

        public virtual void Disable()
        {
            gameObject.SetActive(false);
            if (Pool != null) Pool.ToPool(this);
        }
    }
}
