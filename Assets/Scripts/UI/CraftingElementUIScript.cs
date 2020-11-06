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

    public Transform noSpaceObject;
    public Transform noResourcesObject;

    private void Start()
    {
        noSpaceObject.gameObject.SetActive(false);
        noResourcesObject.gameObject.SetActive(false);

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
        noSpaceObject.gameObject.SetActive(false);
        noResourcesObject.gameObject.SetActive(false);

        var result = craftRecipe.IsCraftable(MainPlayer.mainPlayer.inventory);

        switch (result)
        {
            case ItemResolver.ItemResolver_CraftRecipe.EIsCraftableResult.OK:
                craftRecipe.Craft(MainPlayer.mainPlayer.inventory);
                break;
            case ItemResolver.ItemResolver_CraftRecipe.EIsCraftableResult.NO_RESOURCES:
                noResourcesObject.gameObject.SetActive(true);
                break;
            case ItemResolver.ItemResolver_CraftRecipe.EIsCraftableResult.NO_SPACE:
                noSpaceObject.gameObject.SetActive(true);
                break;
        }
    }
}
