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
        multInput = 1.0f;
        animator.SetTrigger("Attack" + attackIndex);
        //  Debug.Log("Player Attack" + attackIndex + "fired!");
        heavy1 = true;
      /*
        Debug.Log(light1);
        Debug.Log(light2);
        Debug.Log(heavy1);
        Debug.Log(heavy2);
      */
    }
    public override void OnUpdate(AttackType currentAttack)
    {
        base.OnUpdate(currentAttack);
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
                stateMachine.SetNextState(new HeavyComboState());

            } else if (currentAttack == AttackType.light)
            {
                stateMachine.SetNextState(new LightComboState());
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
