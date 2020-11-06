using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public PlayerInventory inventory;
    public PlayerCrafting crafting;
    public GameObject inventoryPanel;
    public GameObject craftingPanel;

    public GameObject inventoryPanelContent;
    public GameObject inventoryPanelItemPrefab;

    public GameObject craftingPanelContent;
    public GameObject craftingPanelItemPrefab;

    private bool isInventoryOpen, isCraftingOpen;

    public void ToggleInventory()
    {
        if (!isInventoryOpen)
            ShowInventory();
        else
            HideInventory();
    }
    public void ToggleCrafting()
    {
        if (!isCraftingOpen)
            ShowCrafting();
        else
            HideCrafting();
    }

    public void ShowInventory()
    {
        if (isCraftingOpen)
            HideCrafting();

        if (!isInventoryOpen)
        {
            inventoryPanelContent.DestroyAllChildren();

            int index = 0;

            foreach (var i in inventory.GetAllItems())
            {
                var obj = GameObject.Instantiate(inventoryPanelItemPrefab, inventoryPanelContent.transform);
                ItemUIScript itemUIScript = obj.GetComponent<ItemUIScript>();
                itemUIScript.itemData = i;
                itemUIScript.itemIndex = index++;
            }

            inventoryPanel.SetActive(true);

            isInventoryOpen = true;
        }
    }
    public void HideInventory()
    {
        if (isInventoryOpen)
        {
            inventoryPanel.SetActive(false);

            isInventoryOpen = false;
        }
    }
    public void ShowCrafting()
    {
        if (isInventoryOpen)
            HideInventory();

        if (!isCraftingOpen)
        {
            craftingPanelContent.DestroyAllChildren();

            foreach (var i in ItemResolver.Instance.crafts)
            {
                var obj = GameObject.Instantiate(craftingPanelItemPrefab, craftingPanelContent.transform);
                CraftingElementUIScript elementUIScript = obj.GetComponent<CraftingElementUIScript>();
                elementUIScript.craftRecipe = i;
            }

            craftingPanel.SetActive(true);

            isCraftingOpen = true;
        }
    }
    public void HideCrafting()
    {
        if (isCraftingOpen)
        {
            craftingPanel.SetActive(false);

            isCraftingOpen = false;
        }
    }

    private void Update()
    {
        if (PauseManager.IsPaused)
        {
            if (!isInventoryOpen && !isCraftingOpen)
            {
                PauseManager.Resume();
            }
        }
        else
        {
            if (isInventoryOpen || isCraftingOpen)
            {
                PauseManager.Pause();
            }
        }
    }
}
public static class GameObjectExtensions
{
    public static void DestroyAllChildren(this GameObject gameObject)
    {
        foreach (Transform t in gameObject.transform)
        {
            GameObject.Destroy(t.gameObject);
        }
    }
}