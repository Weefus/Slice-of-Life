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
        attackWindow = 10;
        attackIndex = 4;
        duration = 1.5f;
        multInput = 1.0f;
        animator.SetTrigger("Attack" + attackIndex);
        //  Debug.Log("Player Attack" + attackIndex + "fired!");
        
      /*
        Debug.Log(light1);
        Debug.Log(light2);
        Debug.Log(heavy1);
        Debug.Log(heavy2);
      */
    }
    public override void OnUpdate(AttackType currentAttack, Attack1 attack1, Attack2 attack2)
    {
        base.OnUpdate(currentAttack, attack1, attack2);
        attack1 = Attack1.heavy;

        if (multInput > 0)
        {
            if (currentAttack == AttackType.heavy)
            {
                stateMachine.SetNextStateToMain();
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
