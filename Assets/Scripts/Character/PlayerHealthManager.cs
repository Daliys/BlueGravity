using System;
using UnityEngine;

namespace Character
{
    /// <summary>
    ///  This class for managing the health of the player.
    /// </summary>
    public class PlayerHealthManager : MonoBehaviour
    {
        public static event Action<int> OnHealthChanged;
        public static event Action OnTakeDamage;

        private const int MaxHealth = 3;
        private int _currentHealth;
        public bool IsDead { get; set; }

        private void Start()
        {
            _currentHealth = MaxHealth;
            OnHealthChanged?.Invoke(_currentHealth);
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            OnHealthChanged?.Invoke(_currentHealth);
            if (_currentHealth <= 0)
            {
                IsDead = true;
            }
            OnTakeDamage?.Invoke();
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