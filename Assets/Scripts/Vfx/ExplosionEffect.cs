using ObjectPool;

namespace TankProject.Vfx
{
    public sealed class ExplosionEffect : VfxBehaviour, IPoolable<ExplosionEffect>
    {
        public Pool<ExplosionEffect> Pool { get; set; }

        public override void Disable()
        {
            base.Disable();
            Pool?.ToPool(this);
        }
    }
}
