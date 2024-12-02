using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase2Transition : StateMachineBehaviour
{

    public Hitbox bigBox;
    public Hitbox cHitBox;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cHitBox = Instantiate(bigBox, new Vector3(animator.transform.position.x, animator.transform.position.y, animator.transform.position.z), bigBox.transform.rotation, animator.transform);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(cHitBox);
    }

    
}
