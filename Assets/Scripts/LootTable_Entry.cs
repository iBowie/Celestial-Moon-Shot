using UnityEngine;

[System.Serializable]
public class LootTable_Entry
{
    public LootTable_Entry()
    {
        minCount = 1;
        maxCount = 1;
    }

    public byte id;
    public float chance;
    public byte minCount;
    public byte maxCount;
}
[System.Serializable]
public class EnemyTable_Entry
{
    public EnemyTable_Entry()
    {

    }

    public GameObject prefab;
    public float chance;
}
