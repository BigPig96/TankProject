using System;
using TankProject.Spawners;
using Zenject;

namespace TankProject.Managers
{
    public sealed class TankManager : IInitializable, IDisposable
    {
        private readonly HeavyTankSpawner _tankSpawner;

        public TankManager(HeavyTankSpawner spawner)
        {
            _tankSpawner = spawner;
        }

        public void Initialize()
        {
            GameManager.OnGameStart += OnGameStarted;
        }

        public void Dispose()
        {
            GameManager.OnGameStart -= OnGameStarted;
        }

        private void OnGameStarted()
        {
            _tankSpawner.Spawn();
        }
    }
}
