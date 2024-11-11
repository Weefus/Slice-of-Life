using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class leak : MonoBehaviour
{
    public float time = 0;
    public float returnTime;
    public float speed;
    public float flight;
    public float damageAmt = 3;
    public float knockbackForce = 5;
    public Vector3 direction;
    public Vector3 locInital;
    public float directionX;
    private Rigidbody2D rigid;
    private GameObject miku;

    // Start is called before the first frame update
    void Awake()
    {
        //locInital = transform.position;
        rigid = GetComponent<Rigidbody2D>();
        miku = GameObject.FindGameObjectWithTag("Miku");

        if(miku != null)
        {
            directionX = -1 * miku.transform.localScale.x;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time > returnTime) {
            rigid.velocity = new Vector3(speed * directionX, 0, 0);
        }
        else
        {
            rigid.velocity = new Vector3(speed * -directionX, 0, 0);
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
        if (col.tag == "Miku")
        {
            Debug.Log("miku");
            Destroy(this.gameObject);
        }
    }
}
