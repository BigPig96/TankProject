using ObjectPool;
using UnityEngine;

namespace TankProject.Vfx
{
    public abstract class VfxBehaviour : MonoBehaviour
    {
        public void Enable(Vector2 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;

            gameObject.SetActive(true);
        }

        public virtual void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
