using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    private ItemSO itemSO;
    public void InitItem(ItemSO itemSO)
    {
        this.itemSO = itemSO;
        string type = "";
        switch (itemSO.itemType)
        {
            case ItemType.Weapon:
                type = "ÎäÆ÷";
                break;
            case ItemType.Consumable:
                type = "ÏûºÄÆ·";
                break;
        }
        iconImage.sprite = itemSO.icon;
        nameText.text = itemSO.name;
        typeText.text = type;
    }

    public void OnClick()
    {
        InventoryUI.instance.OnItemClick(itemSO, this);
    }
}
