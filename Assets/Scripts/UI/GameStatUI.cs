using Character;
using TMPro;
using UnityEngine;

namespace UI
{
    /// <summary>
    ///  This class is responsible for displaying and updating the player's health and coins on the screen.
    /// </summary>
    public class GameStatUI : MonoBehaviour
    {
        [SerializeField] private GameObject health1;
        [SerializeField] private GameObject health2;
        [SerializeField] private GameObject health3;
        
        [SerializeField] private TMP_Text coinText;

        private void OnHealthChangedHandler(int currentHealth)
        { 
            health1.SetActive(currentHealth > 0);
            health2.SetActive(currentHealth > 1);
            health3.SetActive(currentHealth > 2);
        }

        private void OnCoinChangedHandler(int coin)
        {
            coinText.text = coin.ToString();
        }
        
        private void OnEnable()
        {
            PlayerHealthManager.OnHealthChanged += OnHealthChangedHandler;
            Game.OnCoinChanged += OnCoinChangedHandler;
        }
        private void OnDisable()
        {
            PlayerHealthManager.OnHealthChanged -= OnHealthChangedHandler;
            Game.OnCoinChanged -= OnCoinChangedHandler;
        }
    }
}