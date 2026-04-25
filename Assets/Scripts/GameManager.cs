using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy currentEnemy;

    public void Fight()
    {
        player.Attack(currentEnemy);
        currentEnemy.Attack(player);
    }
    void Update ()
    {
        
    }
}



