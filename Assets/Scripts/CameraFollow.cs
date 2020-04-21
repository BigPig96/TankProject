using System;
using TankProject.Managers;
using TankProject.Units;
using UnityEngine;
using Zenject;

namespace TankProject
{
    public sealed class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Transform _target;

        private void Start()
        {
            _target = HeavyTank.Tank.transform;
        }

        private void FixedUpdate()
        {
            if(_target == null) return;
            Vector3 targetPos = new Vector3(_target.position.x, _target.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.fixedDeltaTime);
        }
    }
}
