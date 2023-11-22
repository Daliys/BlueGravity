using System;
using UnityEngine;

namespace Items
{
    [Serializable]
    public class Item
    {
        public string itemName;
        public Sprite sprite;
        public string description;
        /// <summary>
        /// the price of the item in the shop
        /// </summary>
        public int buyPrice;
        /// <summary>
        ///  the price of the item when selling it to the shop
        /// </summary>
        public int sellPrice;
    }
}