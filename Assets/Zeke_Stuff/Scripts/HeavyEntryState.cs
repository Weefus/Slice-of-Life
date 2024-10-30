using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        // attack
        attackWindow = 10;
        attackIndex = 4;
        duration = 1.5f;
        multInput = duration;
        animator.SetTrigger("Attack" + attackIndex);
        Debug.Log("Player Attack" + attackIndex + "fired!");
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (multInput > 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                stateMachine.SetNextStateToMain();
            }
        }


        if (fixedtime >= duration && Input.GetMouseButtonDown(1))
        {
            //Debug.Log(fixedtime);


            if (attackWindow > 0)
            {
                stateMachine.SetNextState(new HeavyComboState());

            }
            else
            {
                stateMachine.SetNextStateToMain();
            }

        }
        else if (fixedtime > (duration * 3))
        {
            stateMachine.SetNextStateToMain();
        }
    }


    public override void OnExit()
    {
        base.OnExit();
        AttackPressedTimer = 0;
    }
}
