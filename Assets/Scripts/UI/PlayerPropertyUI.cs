using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPropertyUI : MonoBehaviour
{
    public static PlayerPropertyUI instance { get; private set; }
    private GameObject uiGameObject;
    private Image hpProgressBar;
    private TextMeshProUGUI hpText;

    private Image levelProgressBar;
    private TextMeshProUGUI levelText;

    private GameObject propertyGrid;
    private GameObject propertyTemplate;
    private Image weaponIcon;
    private PlayerProperty pp;
    private PlayerAttack pa;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        uiGameObject = transform.Find("UI").gameObject;
        hpProgressBar = transform.Find("UI/HPProgressBar/ProgressBar").GetComponent<Image>();
        hpText = transform.Find("UI/HPProgressBar/HPText").GetComponent<TextMeshProUGUI>(); 
        levelProgressBar = transform.Find("UI/LevelProgressBar/ProgressBar").GetComponent<Image>();
        levelText = transform.Find("UI/LevelProgressBar/LevelText").GetComponent<TextMeshProUGUI>();

        propertyGrid = transform.Find("UI/PropertyGrid/").gameObject;
        propertyTemplate = transform.Find("UI/PropertyGrid/PropertyTemplate").gameObject;
        weaponIcon = transform.Find("UI/WeaponIcon").GetComponent<Image>();

        propertyTemplate.SetActive(false);
        GameObject player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        pp = player.GetComponent<PlayerProperty>();
        pa = player.GetComponent<PlayerAttack>();
        UpdatePlayerPropertyUI();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (uiGameObject.activeSelf) 
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }

    public void UpdatePlayerPropertyUI()
    {
        hpProgressBar.fillAmount = pp.hpValue / 100.0f;
        hpText.text = pp.hpValue + "/100";

        levelProgressBar.fillAmount = pp.currentExp*1.0f / (pp.level*30);
        levelText.text = pp.level.ToString();
        ClearGrid();

        AddProperty("生命值: " + pp.hpValue);
        AddProperty("饥饿值: " + pp.energyValue);
        AddProperty("精神值: " + pp.mentalValue);


        foreach (var item in pp.propertyDict)
        {
            string propertyName = "";
            switch (item.Key)
            {
                //case PropertyType.HPValue:
                //    propertyName += "生命值: ";
                //    break;
                //case PropertyType.EnergyValue:
                //    propertyName += "饥饿值: ";
                //    break;
                //case PropertyType.MentalValue:
                //    propertyName += "精神值: ";
                //    break;
                case PropertyType.SpeedValue:
                    propertyName += "速度: ";
                    break;
                case PropertyType.AttackValue:
                    propertyName += "攻击力: ";
                    break;
                default:
                    break;
            }
            int sum = 0;
            foreach (var item1 in item.Value)
            {
                sum += item1.value;
            }
            AddProperty(propertyName + sum);
        }
        if (pa.weaponIcon != null)
            weaponIcon.sprite = pa.weaponIcon;
    }

    private void ClearGrid()
    {
        foreach (Transform child in propertyGrid.transform)
        {
            if (child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void AddProperty(string propertyStr)
    {
        GameObject go = GameObject.Instantiate(propertyTemplate);
        //go.transform.parent = propertyGrid.transform;
        go.transform.SetParent(propertyGrid.transform);
        go.transform.Find("Property").GetComponent<TextMeshProUGUI>().text = propertyStr;
        go.SetActive(true);
    }

    private void Show()
    {
        uiGameObject.SetActive(true);
    }
    private void Hide()
    {
        uiGameObject.SetActive(false);
    }
}
