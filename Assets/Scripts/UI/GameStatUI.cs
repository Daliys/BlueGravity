using System.Collections;
using System.Collections.Generic;
using Character;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    ///  This class is responsible for displaying and updating the player's health and coins on the screen.
    /// </summary>
    public class GameStatUI : MonoBehaviour
    {
        [SerializeField] private Image health1;
        [SerializeField] private Image health2;
        [SerializeField] private Image health3;
        
        [SerializeField] private TMP_Text coinText;
        [SerializeField] private Image damageImage;
        
        private void OnHealthChangedHandler(int currentHealth)
        { 
            health1.color = currentHealth > 0 ? Color.white : Color.black;
            health2.color = currentHealth > 1 ? Color.white : Color.black;
            health3.color = currentHealth > 2 ? Color.white : Color.black;
        }

        private void OnCoinChangedHandler(int coin)
        {
            coinText.text = coin.ToString();
        }
        
        private IEnumerator DamageImageCoroutine()
        {
            while (damageImage.color.a < 0.5f)
            {
                Color color = damageImage.color;
                color.a += Time.deltaTime * 4;
                damageImage.color = color;
                yield return null;
            }
            
            while (damageImage.color.a > 0)
            {
                Color color = damageImage.color;
                color.a -= Time.deltaTime * 4;
                damageImage.color = color;
                yield return null;
            }
        }
        
        private void OnTakeDamageHandler()
        {
            StartCoroutine(DamageImageCoroutine());
        }
        
        
        private void OnEnable()
        {
            PlayerHealthManager.OnHealthChanged += OnHealthChangedHandler;
            PlayerHealthManager.OnTakeDamage += OnTakeDamageHandler;
            Game.OnCoinChanged += OnCoinChangedHandler;
        }
        private void OnDisable()
        {
            PlayerHealthManager.OnHealthChanged -= OnHealthChangedHandler;
            PlayerHealthManager.OnTakeDamage -= OnTakeDamageHandler;
            Game.OnCoinChanged -= OnCoinChangedHandler;
        }
    }
}