using TankProject.Interfaces;
using UnityEngine;

namespace TankProject.Inputs
{
    public sealed class TankWeaponInput : MonoBehaviour, IWeaponInput
    {
        public bool IsAttack() => Input.GetKeyDown(KeyCode.Mouse0);

        public bool PreviousWeapon() => Input.GetKeyDown(KeyCode.Q);

        public bool NextWeapon() => Input.GetKeyDown(KeyCode.E);
    }
}
