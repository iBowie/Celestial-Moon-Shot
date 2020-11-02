using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemBase currentItem;
    public TargetItem target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
}
