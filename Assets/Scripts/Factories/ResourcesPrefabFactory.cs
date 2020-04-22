using Zenject;

namespace TankProject.Factories
{
    public sealed class ResourcesPrefabFactory<T> : IFactory<string, T>
    {
        private readonly DiContainer _container;

        public ResourcesPrefabFactory(DiContainer container)
        {
            _container = container;
        }
        
        public T Create(string path)
        {
            return _container.InstantiatePrefabResourceForComponent<T>(path);
        }
    }
}