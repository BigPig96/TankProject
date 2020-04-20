using System;
using TankProject;
using TankProject.Spawners;
using TankProject.Units;
using UnityEngine;

namespace TankProject.Managers
{
    public sealed class TankManager : MonoBehaviour
    {
        public static TankManager Instance { get; private set; }

        [SerializeField] private HeavyTankSpawner tankSpawner;

        public Transform TankTransform { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void OnEnable()
        {
            GameManager.OnGameStart += OnGameStarted;
        }

        private void OnDisable()
        {
            GameManager.OnGameStart -= OnGameStarted;
        }

        private void OnGameStarted()
        {
            TankTransform = tankSpawner.SpawnTank().transform;
        }
    }
}
