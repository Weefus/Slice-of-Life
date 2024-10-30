using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEntryState : MeleeBaseState
{
        public override void OnEnter(StateMachine stateMachine)
     {
            base.OnEnter(stateMachine);
        attackWindow = 10;
        // attack
       
        attackIndex = 1;
        duration = 1.0f;
        multInput = duration * 2;
        animator.SetTrigger("Attack" + attackIndex);
            //Debug.Log("Player Attack" + attackIndex + "fired!");
    }
     public override void OnUpdate(AttackType currentAttack)
     {
                base.OnUpdate(currentAttack);


        //Debug.Log(multInput);
        if (multInput > 0) 
        { 
        if (currentAttack == AttackType.light)
            {
                stateMachine.SetNextStateToMain();
            }
        }


            if (fixedtime >= duration && lightAttack)
            {
            //Debug.Log(fixedtime);
         

             if (attackWindow > 0)
                {
                    stateMachine.SetNextState(new LightComboState());

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
       // AttackPressedTimer = 0;
    }
}
