using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class mikuMelee : StateMachineBehaviour
{
    public float time = 0;
    public float hitTime;
    public float endTime;
    private Transform transform;
    public float range;
    public int force;
    public Vector3 loc;
    public float dmg;
    private Vector3 direction;
    private bool canHit;
    public LayerMask mask;
    private Collider2D coll;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.GetComponent<Transform>();
        canHit = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        time += Time.deltaTime;
        loc = new Vector3(transform.position.x + (transform.localScale.x * range), transform.position.y, transform.position.z);
        coll = Physics2D.OverlapCircle(loc, range, mask);

        if (coll != null && time >= hitTime && time <= endTime && canHit == true)
        {
            Debug.Log("destroy");
            coll.GetComponent<Player>().hp = coll.GetComponent<Player>().hp -dmg;
            canHit = false;
            direction = (coll.transform.position - transform.position).normalized; //sets direction for the knockback based on the positions of the hitbox and colliding hurtbox
            direction.y += 1f;
            coll.GetComponent<KnockbackController>().Knockback(direction * force);
        }

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        time = 0;
    }
}
