using TankProject.Interfaces;
using UnityEngine;

namespace TankProject.Controllers
{
    public sealed class TankMovementController : MonoBehaviour, IController<IMovementInput>
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Rotate(Vector2 input)
        {
            transform.Rotate(Vector3.back * (rotateSpeed * input.x * Time.deltaTime));
        }

        private void Move(Vector2 input)
        {
            _rb.velocity = transform.up * (moveSpeed * input.y);
        }

        public void Control(IMovementInput input)
        {
            Move(input.MoveDirection());
            Rotate(input.MoveDirection());
        }
    }
}
