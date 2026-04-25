using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float minDamage, maxDamage;
    
    public override void Attack(Character toHit)
    {
        float damage = Random.Range(minDamage, maxDamage);
        toHit.GetHit(damage);
        Debug.Log("I AM ATTACKING THE PLAYER!");
    }

    public void Heal()
    {
        health += 2;
    }
}
