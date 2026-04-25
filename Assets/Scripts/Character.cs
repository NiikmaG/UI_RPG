using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public string charName;
    public float health;

    public abstract void Attack();

    public void GetHit(float damage)
    {
        health = health - damage;
        Debug.Log(charName + "got hit by" + damage + "! Health:" + health);
    }

    public abstract void Attack(Character toHit);
}
