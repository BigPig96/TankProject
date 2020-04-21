using UnityEngine;

namespace TankProject.Spawners
{
    public abstract class SpawnerBase : MonoBehaviour
    {
        public abstract void Spawn();
        public abstract void DeleteAll();
    }
}