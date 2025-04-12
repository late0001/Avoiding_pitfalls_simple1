using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageUI : MonoBehaviour
{
    public static MessageUI instance { get; private set; }

    private TextMeshProUGUI messageText;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject); return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        messageText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if(messageText.enabled)
        {
            Color color = messageText.color;
            float alpha = Mathf.Lerp(color.a, 0, Time.deltaTime);
            messageText.color = new Color(color.r, color.g, color.b, alpha);
            if(alpha == 0f)
            {
                messageText.enabled = false;
            }
        }
    }

    public void Show(string message)
    {
        messageText.enabled = true;
        messageText.text = message;
        messageText.color = Color.white;
    }
    public void Hide()
    {
        messageText.enabled = false;
    }
}
