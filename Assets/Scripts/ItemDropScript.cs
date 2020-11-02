using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropScript : MonoBehaviour
{
    public InventoryItemData itemData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var inv = collision.gameObject.GetComponent<PlayerInventory>();
        if (inv != null)
        {
            inv.items.Add(itemData);
            Destroy(gameObject);
        }
    }
}
