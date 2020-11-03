using UnityEngine;

public class UseableItemBase : ItemBase
{
    public virtual void OnLeftButtonDown() { }
    public virtual void OnLeftButtonUp() { }
    public virtual void OnLeftButtonStay() { }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnLeftButtonDown();
        if (Input.GetMouseButton(0))
            OnLeftButtonStay();
        if (Input.GetMouseButtonUp(0))
            OnLeftButtonUp();
    }
}
