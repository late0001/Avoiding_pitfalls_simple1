using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == Tags.INTERACTABLE)
        {
            PickableObject po = collision.gameObject.GetComponent<PickableObject>();
            if(po != null)
            {
                InventoryManager.instance.AddItem(po.itemSO);
                Destroy(po.gameObject);
            }
        }
    }
}
