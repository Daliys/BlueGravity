using Inventory;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ItemInformationUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text itemNameText;
        [SerializeField] private TMP_Text itemDescriptionText;
        [SerializeField] private TMP_Text itemPriceText;
        [SerializeField] private GameObject coinImage;

        private void OnItemClickedHandler(GameObject sender, ItemEntry item)
        {
            if (item == null)
            {
                itemNameText.text = "";
                itemDescriptionText.text = "";
                itemPriceText.text = "";
                coinImage.SetActive(false);
                return;
            }
            
            itemNameText.text = item.Item.itemName;
            itemDescriptionText.text = item.Item.description;
            itemPriceText.text = item.Item.price.ToString();
            coinImage.SetActive(true);
            
        }

        private void OnEnable()
        {
            InventoryCellUI.OnItemClicked += OnItemClickedHandler;
            OnItemClickedHandler(null, null);
        }
        private void OnDisable()
        {
            InventoryCellUI.OnItemClicked -= OnItemClickedHandler;
        }
    }
}