using TMPro;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private TMP_Text hintText;
      
        private void OpenInventoryPanel()
        {
            inventoryPanel.SetActive(true);
        }
    
        private void CloseInventoryPanel()
        {
            inventoryPanel.SetActive(false);
        }

        private void OnEnable()
        {
            PlayerInput.OnInventoryPressed += OpenInventoryPanel;
            PlayerInput.OnCloseButtonPressed += CloseInventoryPanel;
            ActionEvent.OnHintTextChanged += (text) => hintText.text = text;
        }
    
        private void OnDisable()
        {
            PlayerInput.OnInventoryPressed -= OpenInventoryPanel;
            PlayerInput.OnCloseButtonPressed -= CloseInventoryPanel;
        }
    }
}
