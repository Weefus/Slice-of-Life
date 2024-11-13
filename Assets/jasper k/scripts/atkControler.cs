using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class atkControler : MonoBehaviour
{
    private float time;
    private bool isAtking = false;
    public float duration;
    public float endTime;
    public float startTime;
    private float range;
    public LayerMask mask;
    private Collider2D coll;
    private bool canAtk;
    public float dmg;
    private Vector3 direction;
    public int force;

    // Start is called before the first frame update
    void Start()
    {
        range = transform.localScale.x / 2;
        isAtking = false;
        canAtk = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= duration) {
            isAtking = false;
            canAtk = true;
            GetComponentInParent<zombieMove>().canMove = true;
        }

        if (isAtking) {
            Debug.Log("gggggggggggggggggggggggggggggggggggggg");
            time = time + Time.deltaTime;

            if (startTime <= time && time <= endTime) {


                coll = Physics2D.OverlapCircle(transform.position, range, mask);

                if (coll != null && canAtk) {
                    coll.GetComponent<Player>().hp = coll.GetComponent<Player>().hp - dmg;
                    canAtk = false;
                    direction = (coll.transform.position - transform.parent.position).normalized;
                    direction.y += 1f;
                    coll.GetComponent<KnockbackController>().Knockback(direction * force);
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col) {

        Debug.Log("attack");
    
        isAtking = true;
        GetComponentInParent<zombieMove>().canMove = false;
    }
}
