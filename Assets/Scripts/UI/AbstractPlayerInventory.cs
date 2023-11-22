using System;
using System.Collections.Generic;
using Inventory;
using UI.InventoryCell;
using UnityEngine;

namespace UI
{
    public abstract class AbstractPlayerInventory : MonoBehaviour
    {
        [SerializeField] protected InventorySystem inventorySystem;
        [SerializeField] protected GameObject inventoryPanel;

        private readonly List<InventoryCellUI> _inventoryCells = new();
        protected ClickCellInformation SelectedItem;

        protected virtual void Awake()
        {
            var inventoryCells = inventoryPanel.GetComponentsInChildren<InventoryCellUI>();
            _inventoryCells.AddRange(inventoryCells);
        }

        private void InitializePlayerInventory(List<ItemEntry> items)
        {
            for (var i = 0; i < _inventoryCells.Count; i++)
            {
                _inventoryCells[i].InitializeItem(i < items.Count ? items[i] : null);
            }
        }
        
        protected virtual void OnEnable()
        {
            InventorySystem.OnInventoryChanged += InitializePlayerInventory;
            InitializePlayerInventory(inventorySystem.GetItems()); 
            InventoryCellUI.OnItemClicked += OnItemClickedHandler;
        }
        
        protected virtual void OnDisable()
        {
            InventorySystem.OnInventoryChanged -= InitializePlayerInventory;
            InventoryCellUI.OnItemClicked -= OnItemClickedHandler;
        }
        
        protected abstract void OnItemClickedHandler(ClickCellInformation clickCellInformation);
    }
}