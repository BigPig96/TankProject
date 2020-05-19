using TankProject.Interfaces;
using UnityEngine;

namespace TankProject.Inputs
{
    public sealed class TankMovementInput : MonoBehaviour, IMovementInput
    {
        public Vector2 MoveDirection() => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
