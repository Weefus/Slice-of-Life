using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Player player;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(float damageAmt)
    {
        if (player != null)
        {
            player.hp -= damageAmt;
        }
    }

    public void Knockback(Vector3 force)
    {
        rb2D.velocity = force;
    }
}
