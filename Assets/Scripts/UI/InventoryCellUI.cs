using System;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Class responsible for displaying the item in the inventory.
    /// </summary>
    public class InventoryCellUI : MonoBehaviour, IPointerClickHandler
    {
        public static event Action<GameObject,ItemEntry> OnItemClicked;
        
        [SerializeField] private Image itemImage;
        [SerializeField] private TMP_Text itemCountText;
        [SerializeField] private GameObject selectedBorder;
        
        private ItemEntry _itemEntry;
        
        public void InitializeItem(ItemEntry itemEntry)
        {
            _itemEntry = itemEntry;
            
            if (itemEntry == null)
            {
                itemImage.sprite = null;
                itemImage.color = Color.clear;
                itemCountText.text = "";
                return;
            }
            
            itemImage.color = Color.white;
            itemImage.sprite = itemEntry.Item.sprite;
            itemCountText.text = itemEntry.Item.category == Category.Clothing ? "" : itemEntry.Count.ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnItemClicked?.Invoke(gameObject, _itemEntry);
            
            if (_itemEntry != null)
            {
                selectedBorder.SetActive(!selectedBorder.activeSelf);
            }
        }

        private void OnItemClickedHandler(GameObject clickedGameObject, ItemEntry item)
        {
            if (clickedGameObject != gameObject)
            {
                selectedBorder.SetActive(false);
            }
        }
        
        private void OnEnable()
        {
            OnItemClicked += OnItemClickedHandler;
        }

        private void OnDisable()
        {
            OnItemClicked -= OnItemClickedHandler;
        }
    }
}
