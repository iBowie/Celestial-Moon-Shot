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
}
