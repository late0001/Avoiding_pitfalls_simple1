using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;
    public GameObject propertyGrid;
    public GameObject propertyTemplate;

    private ItemSO itemSO;
    private ItemUI itemUI;
    private void Start()
    {
        propertyTemplate.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void UpdateItemDetailUI(ItemSO itemSO, ItemUI itemUI)
    {
        this.gameObject.SetActive(true);
        this.itemSO = itemSO;
        this.itemUI = itemUI;
        string type = "";
        switch(itemSO.itemType)
        {
            case ItemType.Weapon:
                break;
            case ItemType.Consumable:
                break;
        }

        iconImage.sprite = itemSO.icon;
        nameText.text = itemSO.name;
        typeText.text = type;
        descriptionText.text = itemSO.description;
        foreach(Transform child in propertyGrid.transform)
        {
            if(child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }
        foreach(Property property in itemSO.propertyList)
        {
            string propertyStr = "";
            string propertyName = "";
            switch (property.propertyType) {
                case PropertyType.HPValue:
                    propertyName += "����ֵ: ";
                    break;
                case PropertyType.EnergyValue:
                    propertyName += "����ֵ: ";
                    break;
                case PropertyType.MentalValue:
                    propertyName += "����ֵ: ";
                    break;
                case PropertyType.SpeedValue:
                    propertyName += "�ٶ�: ";
                    break;
                case PropertyType.AttackValue:
                    propertyName += "������: ";
                    break;
                default:
                    break;
            }
            propertyStr += propertyName;
            propertyStr += property.value;
            GameObject go = GameObject.Instantiate(propertyTemplate);
            go.transform.parent = propertyGrid.transform;
            go.transform.Find("Property").GetComponent<TextMeshProUGUI>().text = propertyStr;
            go.SetActive(true);
         }
    }

    public void OnUseButtonClick()
    {
        InventoryUI.instance.OnItemUse(itemSO, itemUI);
        this.gameObject.SetActive(false);
    }
}
