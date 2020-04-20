using UnityEngine;

namespace TankProject
{
    [CreateAssetMenu(fileName = "New Explosion Data", menuName = "Explosion", order = 51)]
    public sealed class ExplosionData : ScriptableObject
    {
        public float damage;
        public float lesionRadius;
        public int maxTargets;
        public LayerMask targetsMask;
    }
}
