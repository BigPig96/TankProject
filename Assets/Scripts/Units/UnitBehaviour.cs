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
            transform.position = position;
            transform.rotation = rotation;
            
            _health.OnDie += OnDie;
            ResetHealth();
            gameObject.SetActive(true);
        }

        public virtual void Disable()
        {
            _health.OnDie -= OnDie;
            gameObject.SetActive(false);
        }
        
        protected virtual void OnDie()
        {
            Disable();
        }
    }
}
