using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAttack playerAttack;
    private PlayerProperty playerProperty;
    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerProperty = GetComponent<PlayerProperty>();
    }
    public void UseItem(ItemSO itemSO)
    {
        switch(itemSO.itemType)
        {
            case ItemType.Weapon:
                playerAttack.LoadWeapon(itemSO);
                playerProperty.UseDrug(itemSO);
                break;
            case ItemType.Consumable:
                playerProperty.UseDrug(itemSO);
                break;
        }
    }
}
