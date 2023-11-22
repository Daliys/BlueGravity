using TMPro;
using UI.InventoryCell;
using UnityEngine;

namespace UI
{
    public class ItemInformationUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text itemNameText;
        [SerializeField] private TMP_Text itemDescriptionText;
        [SerializeField] private TMP_Text itemPriceText;
        [SerializeField] private GameObject coinImage;

        private void OnItemClickedHandler(ClickCellInformation clickCellInformation)
        {
            if (clickCellInformation?.ItemEntry == null)
            {
                itemNameText.text = "";
                itemDescriptionText.text = "";
                itemPriceText.text = "";
                coinImage.SetActive(false);
                return;
            }
            
            itemNameText.text = clickCellInformation.ItemEntry.Item.itemName;
            itemDescriptionText.text = clickCellInformation.ItemEntry .Item.description;
            itemPriceText.text = clickCellInformation.ItemEntry.Item.sellPrice.ToString();
            coinImage.SetActive(true);
            
        }

        private void OnEnable()
        {
            InventoryCellUI.OnItemClicked += OnItemClickedHandler;
            OnItemClickedHandler(null);
        }
        private void OnDisable()
        {
            InventoryCellUI.OnItemClicked -= OnItemClickedHandler;
        }
    }
}