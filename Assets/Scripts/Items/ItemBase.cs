using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public float? reachDistance;

    [HideInInspector]
    public ItemController controller;

    void Awake()
    {
        controller = GetComponent<ItemController>();

        PostAwake();
    }
    protected virtual void PostAwake()
    {

    }

    public void Consume()
    {
        controller.inventory.items.RemoveAt(controller.inventory.selectedItem);
        controller.inventory.selectedItem = -1;
        controller.SetCurrentItem(null);
    }
}
