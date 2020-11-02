using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<InventoryItemData> items = new List<InventoryItemData>();
}

[Serializable]
public class InventoryItemData
{
    public string name;
    public GameObject prefab;
}
