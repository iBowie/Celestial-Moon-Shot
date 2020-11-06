using UnityEngine;
using UnityEngine.UI;

public class CraftingItemDisplayScript : MonoBehaviour
{
    public Image iconImage;
    public Text nameText;
    public ItemResolver.ItemResolver_CraftRecipe.IDAmountPair pair;
    
    private InventoryItemData itemData;

    private void Start()
    {
        if (itemData != null || ItemResolver.Instance.TryGetItem(pair.id, out itemData))
        {
            nameText.text = $"{itemData.displayName} x{pair.amount}";
            iconImage.sprite = itemData.texture;
        }
    }
}
