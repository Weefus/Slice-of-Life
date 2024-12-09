using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blank : StateMachineBehaviour
{


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<basicZombClass>().hp <= (animator.GetComponent<basicZombClass>().maxHP * .5))
        {
            animator.SetTrigger("50%<");
            Debug.Log("trigger");
        }
        if (animator.GetComponent<basicZombClass>().hp <= 0)
        {
            animator.SetTrigger("0Hp");
        }
    }

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
