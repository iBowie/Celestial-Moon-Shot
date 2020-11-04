using System.Linq;
using UnityEngine;

[System.Serializable]
public class LootTable
{
    public LootTable_Entry[] entries;

    public byte[] Resolve()
    {
        float max = entries.Sum(d => d.chance);

        float offset = 0;

        float value = Random.Range(0, max);

        var entry = resolveEntry(ref value, ref offset);

        if (entry == null)
            return new byte[0];
        else
        {
            var count = Random.Range(entry.minCount, entry.maxCount);

            byte[] res = new byte[count];

            for (int i = 0; i < count; i++)
            {
                res[i] = entry.id;
            }

            return res;
        }
    }
    private LootTable_Entry resolveEntry(ref float value, ref float offset)
    {
        foreach (var item in entries)
        {
            if (value <= item.chance + offset)
            {
                return item;
            }
            else
            {
                offset += item.chance;
            }
        }

        return entries.LastOrDefault();
    }
}
