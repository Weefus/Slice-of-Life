using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    
    public Player player;
    public basicZombClass zombClass;
    public UI_Update ui;
    void Start()
    {
        zombClass = GetComponent<basicZombClass>();
        ui = (UI_Update)FindObjectOfType(typeof(UI_Update));
    }

    public void DealDamage(float damageAmt) //deals damage to player
    {
        if (player != null)
        {
            ui = (UI_Update)FindObjectOfType(typeof(UI_Update));
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
