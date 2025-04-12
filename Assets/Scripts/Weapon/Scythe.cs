using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Weapon
{
    public int atkValue = 50;
    public const string ANIM_PARAM_ISATTACK = "isAttack";
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //private void update()
    //{
    //    if(input.getkeydown(keycode.space))
    //    {
    //        attack();
    //    }
    //}
    public override void Attack()
    {
        anim.SetTrigger(ANIM_PARAM_ISATTACK);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.ENEMY)
        {
            other.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }
}
