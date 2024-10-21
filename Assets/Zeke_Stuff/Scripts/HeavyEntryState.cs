using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        // attack
        attackIndex = 4;
        duration = 0.5f;
        animator.SetTrigger("Attack" + attackIndex);
        Debug.Log("Player Attack" + attackIndex + "fired!");
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (fixedtime >= duration)
        {
            if (shouldCombo)
            {
                stateMachine.SetNextState(new HeavyComboState());
                Debug.Log("Followed up the heavy opener");
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }

    }
}
