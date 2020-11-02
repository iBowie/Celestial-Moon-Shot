using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private ItemBase currentItem;
    public TargetItem target;

    // Update is called once per frame
    void Update()
    {
        if (currentItem != null)
        {
            currentItem.target = target;

            target.distance = currentItem.reachDistance;
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
    }
}
