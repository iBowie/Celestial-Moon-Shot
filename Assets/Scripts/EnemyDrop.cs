using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public LootTable table;

    public void ForceDrop()
    {
        foreach (var i in table.Resolve())
        {
            ItemResolver.Instance.SpawnItem(transform.position, i, 1, 0);
        }
    }
}
