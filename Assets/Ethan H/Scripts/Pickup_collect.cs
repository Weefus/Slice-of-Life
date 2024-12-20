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
    public GameObject collParticle;
    ParticlePlayer healParticle;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        healParticle = collision.GetComponent<ParticlePlayer>(); //gets the player's particle player

        if (collision.CompareTag("Player")) {
            Instantiate(collParticle, transform.position, transform.rotation);
            healParticle.PlayHealEffect();
            Destroy(gameObject);
            if(collision.GetComponent("Player") != null)
            {
                player = (Player)collision.GetComponent("Player");
                player.increaseHP(healingValue);
                //player.increaseUlt(ultValue);
            }
        }

    }

}
