using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private ItemBase currentItem;
    public TargetItem target;
    public Text nameText;

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

        currentItem = GameObject.Instantiate<GameObject>(iid.prefab, this.transform).GetComponent<ItemBase>();

        nameText.text = $"Current Item: {currentItem.displayName}";
    }
}
