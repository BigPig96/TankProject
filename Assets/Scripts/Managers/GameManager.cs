using System;
using TankProject.Interfaces;
using TankProject.Units;
using Zenject;

namespace TankProject.Managers
{
    public sealed class GameManager : ITickable, IInitializable, IDisposable
    {
        public enum GameState
        {
            ReadyToStart,
            InGame
        }

        public static event Action OnGameStart;
        public static event Action OnGameOver;

        public GameState State { get; private set; }

        private readonly IStartInput _startInput;
        
        public GameManager(IStartInput startInput)
        {
            _startInput = startInput;
        }

        public void Initialize()
        {
            State = GameState.ReadyToStart;
            HeavyTank.OnPlayerDie += OnPlayerDie;
        }

        public void Dispose()
        {
            HeavyTank.OnPlayerDie -= OnPlayerDie;
        }
        
        public void Tick()
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
