using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightComboState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        // attack
        attackIndex = 2;
        duration = 1.5f;
        animator.SetTrigger("Attack" + attackIndex);
       // Debug.Log("Player Attack" + attackIndex + "fired!");
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (fixedtime >= duration)
        {
         //   Debug.Log("fixed time" +fixedtime + "should combo" + shouldCombo );
            if (shouldCombo)
            {
                stateMachine.SetNextState(new LightFinisherState());
                
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }

    }
    public override void OnExit()
    {
        base.OnExit();
        //AttackPressedTimer = 0;
    }
}
