using System.Collections.Generic;
using Inventory;
using UI.InventoryCell;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// This class is responsible for displaying and updating the inventory on the screen.
    /// </summary>
    public class PlayerInventoryUI : AbstractPlayerInventory
    {
        [SerializeField] protected GameObject deleteButton;
        [SerializeField] protected GameObject useButton;
      
        
        public void OnButtonDeletePressed()
        {
            if(SelectedItem == null) return;
            
            InventoryCellUI inventoryCellUI = SelectedItem.Sender.GetComponent<InventoryCellUI>();
            inventorySystem.RemoveItem(SelectedItem.ItemEntry.Item);
            inventoryCellUI.ResetCellSelection();
            SelectedItem = null;   
        }
        
        public void OnButtonUsePressed()
        {
            InventoryCellUI inventoryCellUI = SelectedItem.Sender.GetComponent<InventoryCellUI>();
            inventorySystem.UseItem(SelectedItem.ItemEntry.Item);
            inventoryCellUI.ResetCellSelection();
            SelectedItem = null;
        }
        
        
        protected override void OnItemClickedHandler(ClickCellInformation clickCellInformation)
        {
            SelectedItem = clickCellInformation;
            
            if (clickCellInformation?.ItemEntry == null)
            {
                deleteButton.SetActive(false);
                useButton.SetActive(false);
                return;
            }
            
            if (clickCellInformation.Sender.GetComponent<InventoryCellUI>() is PlayerInventoryCell)
            {
                deleteButton.SetActive(true);
                useButton.SetActive(true);
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            deleteButton.SetActive(false);
            useButton.SetActive(false);
        }
    }
}