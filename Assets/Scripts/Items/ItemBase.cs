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

    protected virtual void Start() { }
    protected virtual void FixedUpdate() { }
    protected virtual void OnDestroy() { }

    public void Consume(ulong amount = 1)
    {
        controller.inventory.RemoveItem(controller.inventory.itemController.currentItemData.id, amount);
        controller.inventory.selectedItem = -1;
        controller.SetCurrentItem(null);
    }
}
