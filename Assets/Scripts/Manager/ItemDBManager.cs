using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDBManager : MonoBehaviour
{
    public static ItemDBManager instance { get; private set; }

    public ItemDBSO itemDB;
    // Start is called before the first frame update
    void Start()
    {
        if( instance !=null && instance != this)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ItemSO GetRandomItem()
    {
        int index = Random.Range(0, itemDB.itemList.Count);
        return itemDB.itemList[index];
    }
}
