using TankProject.Units;
using Zenject;

namespace Tank.Factories
{
    public class UnitFactory : IFactory<string, UnitBehaviour>
    {
        private DiContainer _container;

        public UnitFactory(DiContainer container)
        {
            _container = container;
        }
        
        public UnitBehaviour Create(string path)
        {
            return _container.InstantiatePrefabResourceForComponent<UnitBehaviour>(path);
        }
    }
}
