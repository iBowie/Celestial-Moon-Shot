using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingElementUIScript : MonoBehaviour
{
    public GameObject inputItemPrefab;
    public GameObject outputItemPrefab;
    public ItemResolver.ItemResolver_CraftRecipe craftRecipe;
    public Transform inputItemsPanel;
    public Transform outputItemsPanel;

    private void Start()
    {
        inputItemsPanel.gameObject.DestroyAllChildren();
        foreach (var i in craftRecipe.input)
        {
            var obj = GameObject.Instantiate(inputItemPrefab, inputItemsPanel);

            CraftingItemDisplayScript dis = obj.GetComponent<CraftingItemDisplayScript>();
            dis.pair = i;
        }
        outputItemsPanel.gameObject.DestroyAllChildren();
        foreach (var i in craftRecipe.output)
        {
            var obj = GameObject.Instantiate(outputItemPrefab, outputItemsPanel);

            CraftingItemDisplayScript dis = obj.GetComponent<CraftingItemDisplayScript>();
            dis.pair = i;
        }
    }

    public void DoCraft()
    {
        if (craftRecipe.IsCraftable(MainPlayer.mainPlayer.inventory))
        {
            craftRecipe.Craft(MainPlayer.mainPlayer.inventory);
        }
    }
}
