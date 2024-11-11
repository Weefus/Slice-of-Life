using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leakMeleeB : StateMachineBehaviour
{
    public float time = 0;
    public float hitBxTime;
    public float detrmin;
    public float endHBox;
    public float range;
    public Vector3 loc;
    private Transform transform;
    public float dmg;
    public float duration;
    


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = time + Time.deltaTime;
        loc = new Vector3(transform.position.x + (transform.localScale.x * range), transform.position.y, transform.position.z);
        Collider2D coll = Physics2D.OverlapCircle(loc, range);

        if (time >= detrmin - .2 && time <= detrmin + .2) {
            if (coll == null) {
                animator.SetTrigger("leakRangedT");
            }   
        }
        if (coll != null && coll.tag == "player" && time >= hitBxTime && time <= endHBox) {
            coll.GetComponent<Hurtbox>().DealDamage(dmg);
        }

        if (time >= duration) {
            animator.SetTrigger("runResum");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0;
        animator.ResetTrigger("leakRangedT");
        animator.ResetTrigger("runResum");

    }
}
