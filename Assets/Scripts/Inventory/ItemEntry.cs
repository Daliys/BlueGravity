using Items;

namespace Inventory
{
    public class ItemEntry
    {
        public Item Item;
        public int Count;
        
        public ItemEntry(Item item, int count)
        {
            Item = item;
            Count = count;
        }

        public ItemEntry()
        {
        }
    }
}