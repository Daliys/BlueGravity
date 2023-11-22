using System.Collections.Generic;
using Inventory;
using Items;
using UI.InventoryCell;
using UnityEngine;

namespace UI
{
    public class StoreUI : AbstractPlayerInventory
    {
        [SerializeField] private GameObject dealerInventoryPanel;
        [SerializeField] private TradeButton tradeButton;
        
        private readonly List<StoreInventoryCell> _dealerInventoryCells = new();
  
        protected override void Awake()
        {
            base.Awake();
            var dealerInventoryCells = dealerInventoryPanel.GetComponentsInChildren<StoreInventoryCell>();
            _dealerInventoryCells.AddRange(dealerInventoryCells);
        }

        public void InitializeDealerInventory(List<Item> items)
        {
            for (var i = 0; i < _dealerInventoryCells.Count; i++)
            {
                _dealerInventoryCells[i].InitializeItem(i < items.Count ? new ItemEntry(items[i], int.MaxValue) : null);
            }
        }
        
        protected override void OnItemClickedHandler(ClickCellInformation clickCellInformation)
        {
            SelectedItem = clickCellInformation;
            
            if (clickCellInformation?.ItemEntry == null)
            {
                tradeButton.SetTradeButton();
                return;
            }
            
            if (clickCellInformation.Sender.GetComponent<InventoryCellUI>() is PlayerInventoryCell)
            {
                tradeButton.SetSellButton();
            }
            else
            {
                tradeButton.SetBuyButton(Game.Instance.HasEnoughCoin(clickCellInformation.ItemEntry.Item.buyPrice));
            }
        }

        public void OnTradeButtonClicked()
        {
            if(SelectedItem == null) return;
            
             
            InventoryCellUI inventoryCellUI = SelectedItem.Sender.GetComponent<InventoryCellUI>();
            
            if (inventoryCellUI is PlayerInventoryCell)
            {
                // sell item to dealer 
                inventorySystem.RemoveItem(SelectedItem.ItemEntry.Item);
                Game.Instance.AddCoin(SelectedItem.ItemEntry.Item.sellPrice);
            }
            else
            {
                // buy item from dealer
                Game.Instance.RemoveCoin(SelectedItem.ItemEntry.Item.buyPrice);
                inventorySystem.AddItem(SelectedItem.ItemEntry.Item);
            }
            
            inventoryCellUI.ResetCellSelection();
            
        }

     
    }
}