using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyComboState : MeleeBaseState
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
        heavy2 = true;
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
       
        if (fixedtime >= duration)
        {
            //   Debug.Log("fixed time" +fixedtime + "should combo" + shouldCombo );
            if (currentAttack == AttackType.heavy)
            {
                stateMachine.SetNextState(new HeavyFinisherState());

            } else if (currentAttack == AttackType.light )
            {
                stateMachine.SetNextState(new LightFinisherState());
            } else if (currentAttack == AttackType.heavy && light1)
            {
                stateMachine.SetNextState(new LHHFinisherState());
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
