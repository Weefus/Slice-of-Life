using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackController : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float startTimer;
    public float knockbackTimer;
    public Vector2 kbForce;
    public Hurtbox hb;

    void Start()
    {
        hb = GetComponent<Hurtbox>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (knockbackTimer > 0)
        {
            knockbackTimer -= Time.deltaTime;
        }

        if (knockbackTimer < 0)
        {
            rb2D.velocity = new Vector2(0f, 0f);
            knockbackTimer = 0;
        }
    }

    public void PlayerKnockback(Vector2 force)
    {
        if (!hb.invincible) 
        {
            knockbackTimer = startTimer;
            if (force.y < 0)
            {
                force.y = 1;
            }
            rb2D.velocity += new Vector2(5f, 5f);
            kbForce = force;
        }  
    }

    public void Knockback(Vector2 force)
    {
        knockbackTimer = startTimer;
        rb2D.velocity = new Vector2(0f, 0f);
        //Debug.Log(force);
        rb2D.velocity = force;
    }
}
