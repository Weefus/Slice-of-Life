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
        duration = 0.5f;
        multInput = duration * 2;
        animator.SetTrigger("Attack" + attackIndex);
  
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

        attack1 = Attack1.light;

        //Debug.Log(multInput);
        if (multInput > 0)
        {
            if (currentAttack == AttackType.light)
            {
                stateMachine.SetNextState(new SpamCooldownState());
            }
        }
     
        
            if (fixedtime >= duration)
            {
            //Debug.Log(fixedtime);
         

             if (currentAttack == AttackType.light)
                {
                    stateMachine.SetNextState(new LightLightState());

            } else if (currentAttack == AttackType.heavy)
            {
                stateMachine.SetNextState(new LightHeavyState());
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
