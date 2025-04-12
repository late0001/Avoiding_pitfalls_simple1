using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : InteractableObject
{
    public ItemSO itemSO;
    protected override void Interact()
    {
        Destroy(this.gameObject);
        InventoryManager.instance.AddItem(itemSO);
    }
}
