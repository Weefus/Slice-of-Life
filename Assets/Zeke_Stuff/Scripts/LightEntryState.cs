using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEntryState : MeleeBaseState
{
        public override void OnEnter(StateMachine stateMachine)
     {
            base.OnEnter(stateMachine);

        // attack
        attackWindow = 0f;
        attackIndex = 1;
        duration = 1.5f;
            animator.SetTrigger("Attack" + attackIndex);
            //Debug.Log("Player Attack" + attackIndex + "fired!");
    }
     public override void OnUpdate()
     {
                base.OnUpdate();
        attackWindow -= Time.deltaTime;
        Debug.Log(attackWindow);
        if (fixedtime >= duration)
        {
            //Debug.Log(fixedtime);
            if (attackWindow > duration)
            {
                stateMachine.SetNextStateToMain();
            }
            else
            {

           
                if (shouldCombo )
                {
                    stateMachine.SetNextState(new LightComboState());

                }
                else
                {
                    stateMachine.SetNextStateToMain();
                }
            }
        }
        
    }
    public override void OnExit()
    {
        base.OnExit();
        AttackPressedTimer = 0;
    }
}
