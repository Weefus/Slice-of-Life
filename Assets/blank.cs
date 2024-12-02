using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blank : StateMachineBehaviour
{


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //leakMeleeT
        //rangedT
        //wave
        //move
        animator.ResetTrigger("leakMeleeT");
        animator.ResetTrigger("wave");
        animator.ResetTrigger("rangedT");
        animator.ResetTrigger("move");
    }



}
