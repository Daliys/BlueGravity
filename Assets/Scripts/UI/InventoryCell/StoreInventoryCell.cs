using Inventory;
using UnityEngine;

namespace UI.InventoryCell
{
    public class StoreInventoryCell : InventoryCellUI
    {
        [SerializeField] private Color textPriceAvailableToBuy;
        [SerializeField] private Color textPriceNotAvailableToBuy;
        
        public override void InitializeItem(ItemEntry itemEntry)
        {
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
                numberText.text = itemEntry.Item.buyPrice.ToString();
                bool isAvailableToBuy = Game.Instance.HasEnoughCoin( itemEntry.Item.buyPrice);
                numberText.color = isAvailableToBuy ? textPriceAvailableToBuy : textPriceNotAvailableToBuy;
                
            }
        }
        
        public void UpdatePrice(int coins)
        {
            if(ItemEntry == null) return;
            
            bool isAvailableToBuy = coins >= ItemEntry.Item.buyPrice;
            numberText.color = isAvailableToBuy ? textPriceAvailableToBuy : textPriceNotAvailableToBuy;
        }


        protected override void OnEnable()
        {
            base.OnEnable();
            Game.OnCoinChanged += UpdatePrice;
        }
        
        protected override void OnDisable()
        {
            base.OnDisable();
            Game.OnCoinChanged -= UpdatePrice;
        }
    }
}