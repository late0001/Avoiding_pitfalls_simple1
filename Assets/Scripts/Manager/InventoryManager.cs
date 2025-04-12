using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject); return;
        }
        instance = this;
    }
    public List<ItemSO> itemList;
    public ItemSO defaultWeapon;

    public void AddItem(ItemSO item)
    {
        itemList.Add(item);
        InventoryUI.instance.addItem(item);
        MessageUI.instance.Show("你已获得了一个：" + item.name);
    }

    public void RemoveItem(ItemSO item)
    {
        itemList.Remove(item);
    }
}
