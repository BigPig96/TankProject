using System.Collections.Generic;
using TankProject.Weapon;
using UnityEngine;

namespace TankProject.Controllers
{
    public sealed class TankWeaponController : MonoBehaviour, IController<IWeaponInput>
    {
        [SerializeField] private List<WeaponBehaviour> weapons;
        private WeaponBehaviour _currentWeapon;
        private int _pointer;

        private void Start()
        {
            Initialize();
        }

        public void Control(IWeaponInput input)
        {
            if (input.IsAttack()) _currentWeapon.Fire();
            if (input.PreviousWeapon()) ChangeWeapon(-1);
            if (input.NextWeapon()) ChangeWeapon(1);
        }

        private void Initialize()
        {
            foreach (var weapon in weapons)
            {
                weapon.Initialize();
            }

            _currentWeapon = weapons[_pointer];
            _currentWeapon.Activate();
            
        }

        private void ChangeWeapon(int changeIndex)
        {
            _pointer += changeIndex;
            if (_pointer < 0) _pointer = weapons.Count - _pointer;
            if (_pointer >= weapons.Count) _pointer -= weapons.Count;

            _currentWeapon.Deactivate();
            _currentWeapon = weapons[_pointer];
            _currentWeapon.Activate();
        }
    }
}
