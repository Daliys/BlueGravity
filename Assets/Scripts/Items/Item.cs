using System;
using UnityEngine;

namespace Items
{
    [Serializable]
    public abstract class Item
    {
        public string itemName;
        public Sprite sprite;
        public string description;
        public int price;
    }
}