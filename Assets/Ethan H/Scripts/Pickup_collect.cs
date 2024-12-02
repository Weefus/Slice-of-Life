using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using TMPro.Examples;

public class Pickup_collect : MonoBehaviour
{
    Player player;
    public int healingValue;
    public int ultValue;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) {
            Destroy(gameObject);
            if(collision.GetComponent("Player") != null)
            {
                player = (Player)collision.GetComponent("Player");
                player.increaseHP(healingValue);
                player.increaseUlt(ultValue);
            }
        }

    }

}
