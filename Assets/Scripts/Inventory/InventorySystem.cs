using System;
using System.Collections.Generic;
using Character;
using Items;
using UnityEngine;

namespace Inventory
{
    /// <summary>
    ///  This class is responsible for storing and updating the inventory.
    /// </summary>
    public class InventorySystem : MonoBehaviour
    {
        public static event Action<List<ItemEntry>> OnInventoryChanged;
        
        private readonly List<ItemEntry> _items = new();
        private const int MaxItems = 12;

        private GameObject _player;

        private void Start()
        {
            OnInventoryChanged?.Invoke(_items);
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        public void AddItem(Item item)
        {
            if (_items.Count >= MaxItems)
            {
                Debug.Log("Inventory is full");
                return;
            }
            
            var itemEntry = _items.Find(entry => entry.Item == item);
            if (itemEntry != null)
            {
                itemEntry.Count++;
            }
            else
            {
                _items.Add(new ItemEntry {Item = item, Count = 1});
            }
            
            OnInventoryChanged?.Invoke(_items);
        }
        
        public void RemoveItem(Item item)
        {
            var itemEntry = _items.Find(entry => entry.Item == item);
            if (itemEntry != null)
            {
                itemEntry.Count--;
                if (itemEntry.Count <= 0)
                {
                    _items.Remove(itemEntry);
                }
                OnInventoryChanged?.Invoke(_items);
            }
        }


        public List<ItemEntry> GetItems()
        {
            return _items;
        }

        public void UseItem(Item itemEntryItem)
        {
            if (_player == null) return;
            
            if (itemEntryItem is ClothItem item)
            {
                _player.GetComponent<SkinChanger>().ChangeSkin(item.skinId);
            }
            RemoveItem(itemEntryItem);
        }
    }
}
