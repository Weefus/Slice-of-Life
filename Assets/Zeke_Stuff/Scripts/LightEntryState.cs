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
        light1 = true;
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

        
        //Debug.Log(multInput);
       if (multInput > 0) 
        { 
        if (currentAttack == AttackType.light)
            {
                stateMachine.SetNextStateToMain();
            }
        }
     
        
            if (fixedtime >= duration)
            {
            //Debug.Log(fixedtime);
         

             if (currentAttack == AttackType.light)
                {
                    stateMachine.SetNextState(new LightComboState());

            } else if (currentAttack == AttackType.heavy)
            {
                stateMachine.SetNextState(new HeavyComboState());
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
       // AttackPressedTimer = 0;
    }
}
