using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLightState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        
        // attack
        attackIndex = 2;
        duration = 1.0f;
        multInput = duration * 2;
        animator.SetTrigger("Attack" + attackIndex);

 
  
       
    }
    public override void OnUpdate(AttackType currentAttack, Attack1 attack1, Attack2 attack2)
    {
        base.OnUpdate(currentAttack, attack1, attack2);

       attack2 = Attack2.light;
        if (fixedtime >= duration)
        {
         //   Debug.Log("fixed time" +fixedtime + "should combo" + shouldCombo );
            if (currentAttack == AttackType.light)
            {
                stateMachine.SetNextState(new LightFinisherState());
                
            } else if (currentAttack == AttackType.heavy)
            {
                stateMachine.SetNextState(new  LLHFinisherState());
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
        //AttackPressedTimer = 0;
    }
}
