using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public PlayerInventory inventory;
    public PlayerCrafting crafting;
    public GameObject inventoryPanel;
    public GameObject craftingPanel;

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
}