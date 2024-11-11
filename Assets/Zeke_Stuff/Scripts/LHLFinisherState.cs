using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHLFinisherState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        // attack
        attackIndex = 8;
        duration = 1.0f;
        animator.SetTrigger("Attack" + attackIndex);
        // Debug.Log("Player Attack" + attackIndex + "fired!");
    }
    public override void OnUpdate(AttackType currentAttack)
    {
        base.OnUpdate(currentAttack);
        if (fixedtime >= duration)
        {
            stateMachine.SetNextStateToMain();
        }

    }
    public override void OnExit()
    {
        base.OnExit();
        AttackPressedTimer = 0;
        light1 = false;
        light2 = false;
        heavy1 = false;
        heavy2 = false;
    }

}

