using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCObject : InteractableObject
{
    public string NPCName;
    public string[] contentList;
    protected override void Interact()
    {
        DialogUI.instance.Show(NPCName, contentList);
    }
}
