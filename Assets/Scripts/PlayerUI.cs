﻿using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public PlayerInventory inventory;
    public PlayerCrafting crafting;
    public GameObject inventoryPanel;
    public GameObject craftingPanel;

    public GameObject inventoryPanelContent;
    public GameObject inventoryPanelItemPrefab;

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
            int childCount = inventoryPanelContent.transform.childCount;
            for (int i = 0; i < childCount; i++)
                GameObject.Destroy(inventoryPanelContent.transform.GetChild(0).gameObject);

            foreach (var i in inventory.GetAllItems())
            {
                var obj = GameObject.Instantiate(inventoryPanelItemPrefab, inventoryPanelContent.transform);
                ItemUIScript itemUIScript = obj.GetComponent<ItemUIScript>();
                itemUIScript.itemData = i;
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