using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeavyEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        // attack
        attackWindow = 0.75f;
        attackIndex = 4;
        duration = 0.65f;
        multInput = 1.0f;
        animator.SetTrigger("Attack" + attackIndex);
        //  Debug.Log("Player Attack" + attackIndex + "fired!");
        
   
    }
    public override void OnUpdate(AttackType currentAttack, Attack1 attack1, Attack2 attack2)
    {
        base.OnUpdate(currentAttack, attack1, attack2);
        attack1 = Attack1.heavy;

        if (multInput > 0)
        {
            if (currentAttack == AttackType.heavy)
            {
                stateMachine.SetNextState(new SpamCooldownState());


            }
        }


        if (fixedtime >= duration)
        {
            //Debug.Log(fixedtime);


            if (currentAttack == AttackType.heavy)
            {
                stateMachine.SetNextState(new HeavyHeavyState());

            } else if (currentAttack == AttackType.light)
            {
                stateMachine.SetNextState(new HeavyLightState());
            }
            else if (fixedtime > (duration * 2))
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
