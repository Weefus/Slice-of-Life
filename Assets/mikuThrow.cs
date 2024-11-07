using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mikuThrow : StateMachineBehaviour
{
    public GameObject leakf;
    public GameObject leakb;
    public Vector3 loc;
    private Transform transform;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.GetComponent<Transform>();
        loc = new Vector3(transform.position.x, transform.position.y - leakb.GetComponent<leak>().radius, 0);

        if (transform.localScale.x > 0) { Instantiate(leakf, loc, leakb.transform.rotation); }
        else { Instantiate(leakb, loc, leakb.transform.rotation); }
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("runResum");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("runResum");
    }

    
}
