using System;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.InventoryCell
{
    /// <summary>
    /// Class responsible for displaying the item in the inventory.
    /// </summary>
    public abstract class InventoryCellUI : MonoBehaviour, IPointerClickHandler
    {
        public static event Action<ClickCellInformation> OnItemClicked;
        
        [SerializeField] protected Image itemImage;
        [SerializeField] protected TMP_Text numberText;
        [SerializeField] protected GameObject selectedBorder;
        
        protected ItemEntry ItemEntry;

        public abstract void InitializeItem(ItemEntry itemEntry);
        
        
        public void ResetCellSelection()
        {
            OnItemClicked?.Invoke(new ClickCellInformation(gameObject, null));
            selectedBorder.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnItemClicked?.Invoke( new ClickCellInformation(gameObject, ItemEntry));
            
            if (ItemEntry != null)
            {
                selectedBorder.SetActive(true);
            }
        }

        private void OnItemClickedHandler( ClickCellInformation clickCellInformation)
        {
            if (clickCellInformation.Sender != gameObject)
            {
                selectedBorder.SetActive(false);
            }
        }
        
        
        
        protected virtual void OnEnable()
        {
            OnItemClicked += OnItemClickedHandler;
        }

        protected virtual void OnDisable()
        {
            OnItemClicked -= OnItemClickedHandler;
        }
    }

    public class ClickCellInformation
    {
        public readonly GameObject Sender;
        public readonly ItemEntry ItemEntry;

        public ClickCellInformation(GameObject sender, ItemEntry itemEntry)
        {
            Sender = sender;
            ItemEntry = itemEntry;
        }
    }
}
