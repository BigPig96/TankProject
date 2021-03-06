﻿using System;
using UnityEngine;

namespace TankProject
{
    public sealed class Health : MonoBehaviour
    {
        public event Action<float> OnHealthChanged;
        public event Action OnDie;

        [SerializeField] private float maxHealth = 100f;
        public float MaxHealth => maxHealth;
        public float CurrentHealth { get; private set; }
        

        public void ResetHealth()
        {
            ChangeHealth(maxHealth);
        }

        public void TakeHeal(float heal)
        {
            ChangeHealth(CurrentHealth + heal);
        }
        
        public void TakeDamage(float damage)
        {
            ChangeHealth(CurrentHealth - damage);
            if (CurrentHealth <= 0) Die();
        }

        private void Die()
        {
            OnDie?.Invoke();
        }
        
        private void ChangeHealth(float health)
        {
            CurrentHealth = Mathf.Clamp(health, 0, maxHealth);
            OnHealthChanged?.Invoke(CurrentHealth);
        }
    }
}