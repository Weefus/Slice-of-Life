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
    public override void OnUpdate(AttackType currentAttack)
    {
        base.OnUpdate(currentAttack);
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
        light1 = false;
        light2 = false;
        heavy1 = false;
        heavy2 = false;
    }
}
