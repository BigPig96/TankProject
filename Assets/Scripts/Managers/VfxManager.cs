using TankProject.Pools;
using TankProject.Vfx;
using UnityEngine;

namespace TankProject
{
    public sealed class VfxManager : MonoBehaviour
    {
        public static VfxManager Instance { get; private set; }

        public VfxPool ExplosionEffectPool { get; private set; }

        [SerializeField] private ExplosionEffect explosionEffect;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            ExplosionEffectPool = VfxPool.Create(explosionEffect, 10, "Explosions");
        }
    }
}
