﻿using UnityEngine;
using UnityEngine.UI;

public class ItemUIScript : MonoBehaviour
{
    public GameObject itemDropPrefab;
    public InventoryItemData itemData;
    public int itemIndex;
    public Text nameText;
    public Text descText;
    public Image iconImage;

    private void Start()
    {
        nameText.text = $"{itemData.displayName} x{itemData.count}";
        descText.text = $"{itemData.description}";
        iconImage.sprite = itemData.texture;
    }

    public void Equip()
    {
        if (itemData.isUseable)
        {
            MainPlayer.mainPlayer.GetComponent<PlayerInventory>().selectedItem = itemIndex;
            MainPlayer.mainPlayer.GetComponent<PlayerUI>().HideInventory();
        }
    }
    public void Drop()
    {
        var obj = GameObject.Instantiate(itemDropPrefab);

        obj.transform.position = MainPlayer.mainPlayer.transform.position;
        ItemDropScript itemDropScript = obj.GetComponent<ItemDropScript>();
        itemDropScript.itemId = itemData.id;
        itemDropScript.itemCount = itemData.count;
        itemDropScript.pickupDelay = 3f;

        GameObject.Destroy(this.gameObject);
    }
}
