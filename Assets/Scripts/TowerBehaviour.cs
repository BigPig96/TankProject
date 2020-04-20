using UnityEngine;

namespace TankProject
{
    public sealed class TowerBehaviour : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed;

        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void Rotate()
        {
            Vector2 pointerPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (pointerPos - (Vector2) transform.position).normalized;
            Quaternion newRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
