using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyHeavyState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        // attack
        attackIndex = 5;
        duration = 0.65f;
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
            if (currentAttack == AttackType.heavy )
            {
                stateMachine.SetNextState(new HeavyFinisherState());

            } else if (currentAttack == AttackType.light)
            {
                stateMachine.SetNextState(new LightFinisherState());
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
