using ObjectPool;
using UnityEngine;

namespace TankProject.Vfx
{
    public abstract class VfxBehaviour : MonoBehaviour, IPoolable<VfxBehaviour>
    {
        public Pool<VfxBehaviour> Pool { get; set; }

        public void Enable(Vector2 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;

            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
            if (Pool != null) Pool.ToPool(this);
        }
    }
}
