using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFinisherState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        // attack
        attackIndex = 3;
        duration = 1.5f;
        animator.SetTrigger("Attack" + attackIndex);
      //  Debug.Log("Player Attack" + attackIndex + "fired!");
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (fixedtime >= duration)
        {
            //Debug.Log(fixedtime);
            stateMachine.SetNextStateToMain();
        }

    }
    public override void OnExit()
    {
        base.OnExit();
        attackWindow = 0;
    }
}
