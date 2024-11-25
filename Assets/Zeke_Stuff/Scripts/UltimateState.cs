using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        stateMachine.isFinisher = true;
        // attack
        attackIndex = 10;
        duration = 3f;
        animator.SetTrigger("Attack" + attackIndex);
        //  Debug.Log("Player Attack" + attackIndex + "fired!");
    }
    public override void OnUpdate(AttackType currentAttack, Attack1 attack1, Attack2 attack2)
    {
        base.OnUpdate(currentAttack, attack1, attack2);
        if (fixedtime >= duration)
        {
            //Debug.Log(fixedtime);
            
            stateMachine.player.decreaseUlt(100);
            stateMachine.SetNextStateToMain();
        }

    }
    public override void OnExit()
    {
        base.OnExit();
        attackWindow = 0;

    }
}
