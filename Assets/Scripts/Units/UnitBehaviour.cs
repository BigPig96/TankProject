using ObjectPool;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace TankProject.Units
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Armor))]
    public abstract class UnitBehaviour : MonoBehaviour, IDamagable
    {
        private Health _health;
        private Armor _armor;

        protected virtual void Awake()
        {
            _health = GetComponent<Health>();
            _armor = GetComponent<Armor>();
        }
        

        protected virtual void OnDie()
        {
            Disable();
        }

        public void TakeDamage(float damage)
        {
            _health.TakeDamage(damage * _armor.GetArmor());
        }

        private void ResetHealth()
        {
            _health.ResetHealth();
        }

        public virtual void Enable(Vector2 position, Quaternion rotation)
        {
            _health.OnDie += OnDie;
            transform.position = position;
            transform.rotation = rotation;
            
            ResetHealth();
            gameObject.SetActive(true);
        }

        public virtual void Disable()
        {
            _health.OnDie -= OnDie;
            gameObject.SetActive(false);
        }
    }
}
