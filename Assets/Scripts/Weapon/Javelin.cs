//using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Javelin : Weapon
{
    public float bulletSpeed;
    public GameObject bulletPrefab;
    private GameObject bulletGo;
    private void Start()
    {
        SpawnBullet();
    }
    public override void Attack()
    {
        if (bulletGo != null) 
        {
            bulletGo.transform.parent = null;
            bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            bulletGo.GetComponent<Collider>().enabled = true;
            Destroy(bulletGo, 10);
            bulletGo = null;
            Invoke("SpawnBullet", 0.5f);
            
        }
        else
        {
            return;
        }
        
    }
    public void SpawnBullet()
    {
        
        bulletGo = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletGo.transform.parent = transform;
        bulletGo.GetComponent<Collider>().enabled = false;
        if(tag == Tags.INTERACTABLE)
        {
            Destroy(bulletGo.GetComponent<JavelinBullet>());
            bulletGo.tag = Tags.INTERACTABLE;
            PickableObject po =  bulletGo.AddComponent<PickableObject>();
            po.itemSO = GetComponent<PickableObject>().itemSO;
            Rigidbody rgd = bulletGo.GetComponent<Rigidbody>();
            rgd.constraints = ~RigidbodyConstraints.FreezePositionY;
            bulletGo.GetComponent<Collider>().enabled = true;
            bulletGo.transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
