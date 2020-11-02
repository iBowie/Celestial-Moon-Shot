using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public ItemController itemController;
    private int _selectedItem = -1;
    public int selectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            if (_selectedItem >= 0)
            {
                itemController.SetCurrentItem(items[value]);
            }
        }
    }
    public List<InventoryItemData> items = new List<InventoryItemData>();

    private void Update()
    {
        if (selectedItem == -1)
        {
            if (items.Count > 0)
            {
                selectedItem = 0;
            }
        }
    }
}

[Serializable]
public class InventoryItemData
{
    public GameObject prefab;
}
