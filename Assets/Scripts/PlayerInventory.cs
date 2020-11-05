using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                itemController.inventory = this;
                itemController.SetCurrentItem(items[value]);
            }
        }
    }
    [SerializeField] private List<InventoryItemData> items = new List<InventoryItemData>();

    private void Update()
    {
        if (PauseManager.IsPaused)
            return;

        if (selectedItem == -1)
        {
            if (items.Count > 0)
            {
                selectedItem = 0;
            }
        }
    }

    public void AddItem(ushort id, ulong amount = 1)
    {
        bool flag = false;

        foreach (var i in items)
        {
            if (i.id == id)
            {
                i.count = (ulong)Mathf.Clamp(i.count + amount, 0, i.maxCount);
                flag = true;
                break;
            }
        }

        if (!flag)
        {
            if (ItemResolver.Instance.TryGetItem(id, out var iid))
            {
                items.Add(iid);
                AddItem(id, amount);
            }
        }
    }
    public void RemoveItem(ushort id, ulong amount = 1)
    {
        foreach (var i in items.ToList())
        {
            if (amount == 0)
                break;

            if (i.id == id)
            {
                if (i.count >= amount)
                {
                    i.count -= amount;
                    if (i.count == 0)
                    {
                        items.Remove(i);
                    }
                    break;
                }
                else if (i.count < amount)
                {
                    ulong c = i.count;
                    i.count -= amount;
                    amount -= c;
                    continue;
                }
            }
        }
    }
    public ulong CountItem(ushort id)
    {
        ulong res = 0;
        foreach (var i in items)
        {
            if (i.id == id)
            {
                res += i.count;
            }
        }
        return res;
    }
    public int UniqueItems => items.Count;
    public IEnumerable<InventoryItemData> GetAllItems()
    {
        return items;
    }
    public void RemoveItemAt(int index)
    {
        items.RemoveAt(index);
    }
}

[Serializable]
public class InventoryItemData : ICloneable
{
    public ushort id;
    public string displayName;
    public string description;
    public Sprite texture;
    public GameObject prefab;
    public ulong maxCount;
    public ulong count;
    public bool isUseable;

    public object Clone()
    {
        return new InventoryItemData()
        {
            id = id,
            displayName = displayName,
            description = description,
            texture = texture,
            prefab = prefab,
            maxCount = maxCount,
            count = count,
            isUseable = isUseable
        };
    }
}
