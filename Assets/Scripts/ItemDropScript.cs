using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ItemDropScript : MonoBehaviour
{
    private InventoryItemData itemData;

    public byte itemId;
    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (ItemResolver.Instance == null || !(itemData == null))
            return;

        ItemResolver.Instance.TryGetItem(itemId, out itemData);

        if (itemData == null)
            return;

        spriteRenderer.sprite = itemData.texture;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Application.isPlaying)
        {
            var inv = collision.gameObject.GetComponent<PlayerInventory>();
            if (inv != null)
            {
                inv.items.Add(itemData);
                Destroy(gameObject);
            }
        }
    }
}
