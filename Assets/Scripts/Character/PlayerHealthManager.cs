using System;
using UnityEngine;

namespace Character
{
    public class PlayerHealthManager : MonoBehaviour
    {
        public static event Action<int> OnHealthChanged;

        private const int MaxHealth = 3;
        private int _currentHealth;
        public bool IsDead { get; set; }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            OnHealthChanged?.Invoke(_currentHealth);
            if (_currentHealth <= 0)
            {
                IsDead = true;
            }
        }
        
        public void Heal(int healAmount)
        {
            _currentHealth += healAmount;
            if (_currentHealth > MaxHealth)
            {
                _currentHealth = MaxHealth;
            }
            OnHealthChanged?.Invoke(_currentHealth);
        }


    }
}