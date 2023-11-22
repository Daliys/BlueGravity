using System;
using System.Collections.Generic;
using InteractableObj;
using Items;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
         public static Action<bool> OnGamePaused;
        
        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private TMP_Text hintText;
        [SerializeField] private StoreUI storeUI;
      
        private void OpenInventoryPanel()
        {
            inventoryPanel.SetActive(true);
            OnGamePaused?.Invoke(true);
        }
    
        private void CloseAllPanel()
        {
            inventoryPanel.SetActive(false);
            storeUI.gameObject.SetActive(false);
            OnGamePaused?.Invoke(false);
        }
        

        private void OpenStorePanel(List<Item> items)
        {
            storeUI.gameObject.SetActive(true);
            storeUI.InitializeDealerInventory(items);
            OnGamePaused?.Invoke(true);
        }
        
        private void OnEnable()
        {
            PlayerInput.OnInventoryPressed += OpenInventoryPanel;
            PlayerInput.OnCloseButtonPressed += CloseAllPanel;
            ActionEvent.OnHintTextChanged += (text) => hintText.text = text;
            ShopDealer.OnShopDealerInteracted += OpenStorePanel;
        }
    
        private void OnDisable()
        {
            PlayerInput.OnInventoryPressed -= OpenInventoryPanel;
            PlayerInput.OnCloseButtonPressed -= CloseAllPanel;
            ShopDealer.OnShopDealerInteracted -= OpenStorePanel;
        }
    }
}
