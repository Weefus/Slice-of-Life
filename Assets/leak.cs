using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leak : MonoBehaviour
{

    public float moveSpeed, radius;
    public float angle;
    public float damageAmt = 3;
    public float knockbackForce = 5;
    public Vector3 direction;
    public Vector3 locInital;
    public float dircetion;

    // Start is called before the first frame update
    void Start()
    {
        locInital = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        angle += moveSpeed * Time.deltaTime;
        if (dircetion > 0)
        {
            transform.position = new Vector3(locInital.x + (radius * Mathf.Cos(angle)), locInital.y + (radius * Mathf.Sin(angle)), 0);
        }
        else {
            transform.position = new Vector3(locInital.x - (radius * Mathf.Cos(angle)), locInital.y - (radius * Mathf.Sin(angle)), 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            Hurtbox h = col.GetComponent<Hurtbox>();
            KnockbackController kb = col.GetComponent<KnockbackController>();
            direction = (h.transform.position - transform.position).normalized; //sets direction for the knockback based on the positions of the hitbox and colliding hurtbox
            direction.y += 1f;
            kb.Knockback(direction * knockbackForce);
            h.DealDamage(damageAmt);
        }

        Destroy(this.gameObject);
    }
}
