using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using TMPro.Examples;

public class Pickup_collect : MonoBehaviour
{
    public TMP_Text uiText;
    public Player player;
    public int healingValue = 25;
    public UI_Update ui;

    void Start()
    {
        uiText.text = "HP: " + player.hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) {
            Destroy(gameObject);
            player.increaseHP(healingValue);
            ui.updateHP();
        }

        if (player.hp >= player.maxHP)
        {
            player.hp = player.maxHP;
            Debug.Log("Test");
            ui.updateHP();
        }
        if (player.hp <= 0)
        {
            player.hp = 0;
            Debug.Log("Test");
            ui.updateHP();
        }

    }

}
