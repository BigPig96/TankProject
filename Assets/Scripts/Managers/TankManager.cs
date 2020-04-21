using TankProject.Spawners;
using UnityEngine;

namespace TankProject.Managers
{
    public sealed class TankManager : MonoBehaviour
    {
        public static TankManager Instance { get; private set; }

        [SerializeField] private HeavyTankSpawner tankSpawner;
        

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
            tankSpawner.Spawn();
        }
    }
}
