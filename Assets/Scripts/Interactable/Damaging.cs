using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    [SerializeField] bool damage_on_contact, damage_on_hit, damage_on_drop;
    [SerializeField] int damage = 1;


    public void Initialize()
    {

    }

    public void OnHit(PlayerHealth player)
    {
        //fx
    }

    public int GetDamage()
    {
        return damage;
    }

    public bool GetDmgOnContact()
    {
        return damage_on_contact;
    }

    public bool GetDmgOnHit()
    {
        return damage_on_hit;
    }

    public bool GetDmgOnDrop()
    {
        return damage_on_drop;
    }
}
