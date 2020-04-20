using UnityEngine;

namespace TankProject
{
    public class Armor : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float armor = 1f;

        public float GetArmor() => armor;
    }
}