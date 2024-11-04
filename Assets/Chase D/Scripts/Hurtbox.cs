using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    
    public Player player;
    public basicZombClass zombClass;
    public UI_Update ui;
    void Start()
    {
        player = GetComponent<Player>();
        zombClass = GetComponent<basicZombClass>();
    }

    public void DealDamage(float damageAmt) //deals damage to player
    {
        if (player != null)
        {
            player.decreaseHP(damageAmt);

            if (ui != null)
            {
                ui.updateHP();
            }
        }

        if (zombClass != null)
        {
            zombClass.hp -= damageAmt;
        }
    }
}
