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
        loc = new Vector3(transform.position.x + (transform.localScale.x * 1.5f), transform.position.y, 0);

        Instantiate(leakf, loc, leakf.transform.rotation);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
