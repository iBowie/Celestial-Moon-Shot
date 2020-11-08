using UnityEngine;
using UnityEngine.UI;

public class ItemUIScript : MonoBehaviour
{
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
        ItemResolver.Instance.SpawnItem(MainPlayer.mainPlayer.transform.position, itemData.id, itemData.count, 3f);

        var parent = this.gameObject.transform.parent;

        bool flag = false;

        foreach (Transform t in parent)
        {
            if (t == this.gameObject.transform)
            {
                flag = true;
            }
            else if (flag)
            {
                t.GetComponent<ItemUIScript>().itemIndex--;
            }
        }

        MainPlayer.mainPlayer.GetComponent<PlayerInventory>().RemoveItemAt(itemIndex);

        GameObject.Destroy(this.gameObject);
    }
}
