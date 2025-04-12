using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;
    private List<string> contentList;
    private int contentIndex;
    public static DialogUI instance { get; private set; }
    private Action OnDialogEnd;
    private GameObject uiGameObject;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        nameText = transform.Find("UI/NameBg/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("UI/ContentText").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("UI/ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(ContinueBtnOnClick);
        uiGameObject = transform.Find("UI").gameObject;
        Hide();
    }
    public void Show() 
    {
        uiGameObject.SetActive(true);
    }

    public void Show(string name, string[] content, Action OnDialogEnd = null)
    {
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentText.text = contentList[0];
        uiGameObject.SetActive(true);
        this.OnDialogEnd = OnDialogEnd;
    }
    public void Hide()
    {
        contentIndex = 0;
        uiGameObject.SetActive(false);
    }

    void ContinueBtnOnClick() 
    {
        contentIndex++;
        if(contentIndex >= contentList.Count)
        {
            OnDialogEnd?.Invoke();
            Hide();
            return;
        }
        contentText.text = contentList[contentIndex];
    }
}
