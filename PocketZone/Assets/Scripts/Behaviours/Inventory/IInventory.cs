using Data;

namespace Behaviours
{
    interface IInventory
    {
        bool TryAddItem(ItemInfo item);
        bool TryRemoveItem(ItemInfo item);
        void AddItem(ItemInfo item);
        void RemoveItem(ItemInfo item);
    }

}
