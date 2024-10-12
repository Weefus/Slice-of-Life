using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    
    public Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }

    public void DealDamage(float damageAmt) //deals damage to player
    {
        if (player != null)
        {
            player.hp -= damageAmt;
        }
    }
}
