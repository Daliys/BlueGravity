using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    
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
        Input.OnInventoryPressed += OpenInventoryPanel;
        Input.OnCloseButtonPressed += CloseInventoryPanel;
    }
    
    private void OnDisable()
    {
        Input.OnInventoryPressed -= OpenInventoryPanel;
        Input.OnCloseButtonPressed -= CloseInventoryPanel;
    }
}
