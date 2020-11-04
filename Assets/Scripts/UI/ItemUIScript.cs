using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIScript : MonoBehaviour
{
    public InventoryItemData itemData;
    public Text nameText;
    public Text descText;
    public Image iconImage;

    private void Start()
    {
        nameText.text = $"{itemData.displayName} x{itemData.count}";
        descText.text = $"{itemData.description}";
        iconImage.sprite = itemData.texture;
    }
}
