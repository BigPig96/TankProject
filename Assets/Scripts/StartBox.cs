using TankProject.Managers;
using TankProject.Units;
using UnityEngine;

namespace TankProject
{
    public sealed class StartBox : MonoBehaviour
    {
        private UnitBehaviour[] units;

        private void Start()
        {
            units = new UnitBehaviour[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                units[i] = transform.GetChild(i).GetComponent<UnitBehaviour>();
            }
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
            foreach (var unit in units)
            {
                var unitTransform = unit.transform;
                unit.Enable(unitTransform.position, unitTransform.rotation);
            }
        }
    }
}
