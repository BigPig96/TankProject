using TankProject.Managers;
using UnityEngine;

namespace TankProject.Inputs
{
    public sealed class SeekerMovementInput : MonoBehaviour, IMovementInput
    {
        private Transform _target;

        private void Start()
        {
            _target = TankManager.Instance.TankTransform;
        }

        public Vector2 MoveDirection()
        {
            
            return _target != null && _target.gameObject.activeInHierarchy
                ? (Vector2)(_target.position - transform.position).normalized
                : Vector2.zero;
        }
    }
}
