using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHeavyState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        // attack
        attackIndex = 5;
        duration = 1.5f;
        multInput = duration * 2;
        animator.SetTrigger("Attack" + attackIndex);
        //  Debug.Log("Player Attack" + attackIndex + "fired!");


    }
    public override void OnUpdate(AttackType currentAttack, Attack1 attack1, Attack2 attack2)
    {
        base.OnUpdate(currentAttack, attack1, attack2);

        attack2 = Attack2.heavy;

        if (fixedtime >= duration)
        {
            //   Debug.Log("fixed time" +fixedtime + "should combo" + shouldCombo );
            if (currentAttack == AttackType.heavy)
            {
                stateMachine.SetNextState(new LHHFinisherState());

            }
            else if (currentAttack == AttackType.light)
            {
                stateMachine.SetNextState(new LHLFinisherState());
            }
            else if (fixedtime > duration * 2)
            {
                stateMachine.SetNextStateToMain();
            }

        }


    }
    public override void OnExit()
    {
        base.OnExit();
        AttackPressedTimer = 0;
    }
}
