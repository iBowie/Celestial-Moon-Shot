using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ItemResolver : MonoBehaviour
{
    public static ItemResolver Instance { get; private set; }

    private void OnEnable()
    {
        Instance = this;
    }
    private void OnDisable()
    {
        Instance = null;
    }

    public List<ItemResolver_Entry> items;
    public List<ItemResolver_CraftRecipe> crafts;

    public bool TryGetItem(ushort id, out InventoryItemData iid)
    {
        if (items != null)
        {
            foreach (var ire in items)
            {
                if (ire.itemData.id == id)
                {
                    iid = ire.itemData;
                    return true;
                }
            }
        }

        iid = null;
        return false;
    }

    [Serializable]
    public class ItemResolver_Entry
    {
        public InventoryItemData itemData;
    }
    [Serializable]
    public class ItemResolver_CraftRecipe
    {
        public List<IDAmountPair> input;
        public List<IDAmountPair> output;

        public bool IsCraftable(PlayerInventory inventory)
        {
            foreach (var i in input)
            {
                if (inventory.CountItem(i.id) < i.amount)
                    return false;
            }

            return true;
        }
        public void Craft(PlayerInventory inventory)
        {
            foreach (var i in input)
            {
                inventory.RemoveItem(i.id, i.amount);
            }
            foreach (var o in output)
            {
                inventory.AddItem(o.id, o.amount);
            }
        }

        [Serializable]
        public class IDAmountPair
        {
            public ushort id;
            public ulong amount;
        }
    }
}
