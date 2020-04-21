using TankProject.Units;
using UnityEngine;
using Zenject;

namespace TankProject.Inputs
{
    public sealed class SeekerMovementInput : MonoBehaviour, IMovementInput
    {
        private Transform _target;

        private void Start()
        {
            _target = HeavyTank.Tank.transform;
        }

        public Vector2 MoveDirection()
        {
            
            return _target != null && _target.gameObject.activeInHierarchy
                ? (Vector2)(_target.position - transform.position).normalized
                : Vector2.zero;
        }
    }
}
