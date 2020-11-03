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

    public bool TryGetItem(byte id, out InventoryItemData iid)
    {
        if (items != null)
        {
            foreach (var ire in items)
            {
                if (ire.id == id)
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
        public byte id;
        public InventoryItemData itemData;
    }
}
