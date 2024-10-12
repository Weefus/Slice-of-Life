using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float startTimer = 1;
    public float knockbackTimer;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (knockbackTimer > 0)
        {
            knockbackTimer -= Time.deltaTime;
        }
    }

    public void Knockback(Vector3 force)
    {
        knockbackTimer = startTimer;
        rb2D.velocity = force;
    }
}
