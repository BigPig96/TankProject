using TankProject.Vfx;
using Zenject;

namespace Tank.Factories
{
    public class VfxFactory : IFactory<string, VfxBehaviour>
    {
        private DiContainer _container;

        public VfxFactory(DiContainer container)
        {
            _container = container;
        }
        
        public VfxBehaviour Create(string path)
        {
            return _container.InstantiatePrefabResourceForComponent<VfxBehaviour>(path);
        }
    }
}