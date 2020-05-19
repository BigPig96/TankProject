using Lib;
using UnityEngine;

namespace TankProject.Shell
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ShellBehaviour : MonoBehaviour
    {
        [SerializeField] protected float lifetime;
        [SerializeField] protected float speed;

        protected Rigidbody2D RBody;

        private Wait _destruction;

        protected virtual void Awake()
        {
            RBody = GetComponent<Rigidbody2D>();
            _destruction = this.WaitForSeconds(lifetime, Disable);
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            Destruct();
        }

        protected virtual void Destruct()
        {
            Disable();
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
        }
    }
}
