using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public float? reachDistance;
    [HideInInspector]
    public TargetItem target;
    public string displayName;
}
