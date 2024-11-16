using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    private bool canHit;
    private bool isAtking;
    public bool canMove;
    public float time;
    public LayerMask mask;
    public float startTS;
    public float endTS;
    public float durationS;
    public Collider2D coll;
    public float dmg;
    public Vector3 direction;
    public int force;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        isAtking = false;
        canMove = true;
        canHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= durationS) {
            isAtking = false;
            canMove = true;
            canHit = true;
            transform.parent.GetComponent<zombieMove>().canMove = true;
        }

        if (isAtking)
        {
            time = time + Time.deltaTime;

            if (startTS < time && time < endTS && canHit)
            {

                coll = Physics2D.OverlapCircle(transform.position, range/2, mask);

                if (coll != null)
                {

                    coll.GetComponent<Hurtbox>().DealDamage(dmg);
                    canHit = false;
                    direction = (coll.transform.position - transform.parent.position).normalized;
                    //Debug.Log(direction);
                    
                    Debug.Log(direction);
                    direction.y += 1f;
                    Debug.Log(direction);
                    coll.GetComponent<KnockbackController>().PlayerKnockback(direction * force);
                }
            }
        }
        else { time = 0; }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Player") { 
            Debug.Log("triggered");
            isAtking = true;
            canMove=false;
            transform.parent.GetComponent<zombieMove>().canMove = false;

        }
    }
}
