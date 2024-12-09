using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamCooldownState : MeleeBaseState
{
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        attackWindow = 10;
        // attack

      
        duration = 0.3f;
        multInput = duration * 2;
       

  
    }
    public override void OnUpdate(AttackType currentAttack, Attack1 attack1, Attack2 attack2)
    {
        base.OnUpdate(currentAttack, attack1, attack2);

    

        //Debug.Log(multInput);
        


        if (fixedtime >= duration)
        {
            stateMachine.SetNextStateToMain();
        }

    }

    public override void OnExit()
    {
        base.OnExit();
        // AttackPressedTimer = 0;
    }
}