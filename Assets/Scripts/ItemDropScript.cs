using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ItemDropScript : MonoBehaviour, IHasToolTip
{
    private InventoryItemData itemData;

    public ushort itemId;
    public ulong itemCount;
    public SpriteRenderer spriteRenderer;

    public string ToolTip => itemData == null ? "" : itemData.displayName;

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
                inv.AddItem(itemId, itemCount);
                Destroy(gameObject);
            }
        }
    }
}
