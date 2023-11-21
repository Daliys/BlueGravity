using System.Collections.Generic;
using Inventory;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// This class is responsible for displaying and updating the inventory on the screen.
    /// </summary>
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryPanel;
        private readonly List<InventoryCellUI> _inventoryCells = new();
        
        private void Awake()
        {
            var inventoryCells = inventoryPanel.GetComponentsInChildren<InventoryCellUI>();
            _inventoryCells.AddRange(inventoryCells);
        }
        
        /// <summary>
        ///  This method is called when the inventory is changed.
        /// </summary>
        private void OnInventoryChangedHandler(List<ItemEntry> items)
        {
            for (var i = 0; i < _inventoryCells.Count; i++)
            {
                _inventoryCells[i].InitializeItem(i < items.Count ? items[i] : null);
            }
        }

        private void OnEnable()
        {
            InventorySystem.OnInventoryChanged += OnInventoryChangedHandler;
        }
        
        private void OnDisable()
        {
            InventorySystem.OnInventoryChanged -= OnInventoryChangedHandler;
        }
    }
}