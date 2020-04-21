using System;
using TankProject.Units;
using UnityEngine;
using Zenject;

namespace TankProject.Managers
{
    public sealed class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            ReadyToStart,
            InGame
        }
        
        public static GameManager Instance { get; private set; }

        public static event Action OnGameStart;
        public static event Action OnGameOver;

        public GameState State { get; private set; }

        private IStartInput _startInput;

        [Inject]
        private void InstallBindings(IStartInput startInput)
        {
            _startInput = startInput;
        }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
            
            State = GameState.ReadyToStart;
        }

        private void OnEnable()
        {
            HeavyTank.OnPlayerDie += OnPlayerDie;
        }

        private void OnDisable()
        {
            HeavyTank.OnPlayerDie -= OnPlayerDie;
        }

        private void Update()
        {
            if(State == GameState.ReadyToStart &&  _startInput.IsGameStart())
                StartGame();
        }

        private void StartGame()
        {
            State = GameState.InGame;
            OnGameStart?.Invoke();
        }
        
        private void OnPlayerDie()
        {
            State = GameState.ReadyToStart;
            OnGameOver?.Invoke();
        }
    }
}
