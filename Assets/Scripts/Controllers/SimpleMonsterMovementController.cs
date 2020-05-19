using TankProject.Interfaces;
using UnityEngine;

namespace TankProject.Controllers
{
    public sealed class SimpleMonsterMovementController : MonoBehaviour, IController<IMovementInput>
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed = 20;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Control(IMovementInput input)
        {
            Move(input.MoveDirection());
            Rotate(input.MoveDirection());
        }

        private void Move(Vector2 input)
        {
            _rb.velocity = input * moveSpeed;
        }

        private void Rotate(Vector2 input)
        {
            if(input == Vector2.zero) return;
            var newRotation = Quaternion.LookRotation(Vector3.forward, input);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
