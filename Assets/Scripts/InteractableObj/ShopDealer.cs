using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;

namespace InteractableObj
{
    public class ShopDealer : Interactable
    {
        [SerializeField] private GameItems gameItems;
        [SerializeField] private TypeOfCellingItems typeOfCellingItems;
 
        public static event System.Action<List<Item>> OnShopDealerInteracted;
        
        enum TypeOfCellingItems
        {
            Clothes,
            Potions,
            All
        }
        
        protected override string GetHintTextOnCollide()
        {
            return GameStrings.ShopDealer;
        }

        protected override void Interact()
        {
            OnShopDealerInteracted?.Invoke(GetAvailableItems());
        }
        
        private List<Item> GetAvailableItems()
        {
            var availableItems = new List<Item>();
            
            switch (typeOfCellingItems)
            {
                case TypeOfCellingItems.Clothes: 
                    availableItems.AddRange(gameItems.clothItems);
                    break;
                case TypeOfCellingItems.Potions:
                    //availableItems.AddRange(gameItems.);
                    break;
                case TypeOfCellingItems.All:
                    availableItems.AddRange(gameItems.clothItems);
                   // availableItems.AddRange(gameItems.potionItems);
                    break;
            }
            return availableItems;
        }

        
    }
}