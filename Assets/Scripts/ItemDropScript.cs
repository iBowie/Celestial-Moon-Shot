using UnityEngine;

[ExecuteInEditMode]
public class ItemDropScript : MonoBehaviour, IHasToolTip
{
    private InventoryItemData itemData;
    private float dropTime;

    public ushort itemId;
    public ulong itemCount;
    public SpriteRenderer spriteRenderer;
    public float pickupDelay;

    public string ToolTip => itemData == null ? "" : itemData.displayName;

    private void Start()
    {
        dropTime = Time.time;
    }

    private void Update()
    {
        if (ItemResolver.Instance == null || !(itemData == null))
            return;

        ItemResolver.Instance.TryGetItem(itemId, out itemData);

        if (itemData == null)
            return;

        spriteRenderer.sprite = itemData.texture;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Application.isPlaying)
        {
            if (!PauseManager.IsPaused)
            {
                if (Time.time - dropTime >= pickupDelay)
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
    }
}
