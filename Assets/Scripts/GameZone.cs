using TankProject.Units;
using UnityEngine;

namespace TankProject
{
    public sealed class GameZone : MonoBehaviour
    {
        private void OnCollisionExit2D(Collision2D other)
        {
            MonsterBehaviour monster = other.gameObject.GetComponent<MonsterBehaviour>();
            if (monster == null) return;
            monster.ChangeBodyType(RigidbodyType2D.Dynamic);
        }
    }
}
