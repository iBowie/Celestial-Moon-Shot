using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private ItemBase currentItem;
    [HideInInspector]
    public InventoryItemData currentItemData;
    public TargetItem target;
    public Text nameText;
    public PlayerInventory inventory;

    // Update is called once per frame
    void Update()
    {
        if (currentItem != null)
        {
            target.distance = currentItem.reachDistance;

            currentItem.controller = this;
        }
        else
        {
            target.distance = null;
        }
    }

    public void SetCurrentItem(InventoryItemData iid)
    {
        if (currentItem != null)
        {
            Destroy(currentItem.gameObject);
        }

        if (iid != null)
        {
            if (iid.isUseable)
            {
                currentItem = GameObject.Instantiate<GameObject>(iid.prefab, this.transform).GetComponent<ItemBase>();
            }
            currentItemData = iid;

            nameText.text = $"Current Item: {iid.displayName}";
        }
        else
        {
            currentItem = null;
            currentItemData = null;

            nameText.text = $"Current Item: none";
        }
    }
}
