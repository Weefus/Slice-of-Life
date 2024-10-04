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

    void Start()
    {
        uiText.text = "HP: " + player.hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) {
            Destroy(gameObject);
            player.hp += 25;
            uiText.text = "HP: " + player.hp;
        }
    }
}
