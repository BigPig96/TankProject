using System;
using TankProject.Managers;
using TankProject.Units;
using UnityEngine;

namespace TankProject
{
    public sealed class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed;

        private void OnEnable()
        {
            GameManager.OnGameStart += OnGameStart;
        }

        private void OnGameStart()
        {
            FindPlayer();
        }

        private void FindPlayer()
        {
            target = TankManager.Instance.TankTransform;
        }

        private void FixedUpdate()
        {
            if(target == null) return;
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.fixedDeltaTime);
        }
    }
}
