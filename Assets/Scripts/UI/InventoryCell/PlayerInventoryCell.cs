using Inventory;
using UnityEngine;

namespace UI.InventoryCell
{
    public class PlayerInventoryCell : InventoryCellUI
    {
        public override void InitializeItem(ItemEntry itemEntry)
        {
            ItemEntry = itemEntry;
            
            if (itemEntry == null)
            {
                itemImage.sprite = null;
                itemImage.color = Color.clear;
                numberText.text = "";
                return;
            }
            
            itemImage.color = Color.white;
            itemImage.sprite = itemEntry.Item.sprite;
            numberText.text = itemEntry.Count == 1 ? "" : 'x' + itemEntry.Count.ToString();
        }
    }
}