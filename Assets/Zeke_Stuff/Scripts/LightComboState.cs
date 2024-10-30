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
        duration = 1.0f;
        multInput = duration * 2;
        animator.SetTrigger("Attack" + attackIndex);
       // Debug.Log("Player Attack" + attackIndex + "fired!");
    }
    public override void OnUpdate()
    {
        base.OnUpdate();

        if (multInput > 0)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                stateMachine.SetNextStateToMain();
            }
        }
        if (fixedtime >= duration)
        {
         //   Debug.Log("fixed time" +fixedtime + "should combo" + shouldCombo );
            if (attackWindow > 0)
            {
                stateMachine.SetNextState(new LightFinisherState());
                
            }
            
        }
        else if(fixedtime > duration * 3) 
        {
            stateMachine.SetNextStateToMain();
        }

    }
    public override void OnExit()
    {
        base.OnExit();
        //AttackPressedTimer = 0;
    }
}
