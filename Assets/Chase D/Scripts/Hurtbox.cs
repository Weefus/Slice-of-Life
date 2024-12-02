using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    
    public Player player;
    public basicZombClass zombClass;
    public UI_Update ui;
    private float invincibleTimer;
    public bool invincible;
    SpriteRenderer playerRender;
    void Start()
    {
        playerRender = gameObject.GetComponent<SpriteRenderer>();
        zombClass = GetComponent<basicZombClass>();
        ui = (UI_Update)FindObjectOfType(typeof(UI_Update));
    }

    private void Update()
    {
        if (invincibleTimer > 0)
        {
            invincibleTimer -= Time.deltaTime;
            invincible = true;
            playerRender.color = new Color(playerRender.color.r, playerRender.color.g, playerRender.color.b, 0.6f);
        } else
        {
            invincible = false;
            playerRender.color = new Color(playerRender.color.r, playerRender.color.g, playerRender.color.b, 1);
        }
    }

    public void DealDamage(float damageAmt) //deals damage to player
    {
        if (player != null && !invincible)
        {
            invincibleTimer = 3;

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
