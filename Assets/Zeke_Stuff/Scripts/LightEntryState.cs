using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEntryState : MeleeBaseState
{
        public override void OnEnter(StateMachine stateMachine)
     {
            base.OnEnter(stateMachine);
        
         // attack
        attackIndex = 1;
        duration = 0.5f;
            animator.SetTrigger("Attack" + attackIndex);
            Debug.Log("Player Attack" + attackIndex + "fired!");
    }
     public override void OnUpdate()
     {
                base.OnUpdate();
            if(fixedtime >= duration) {
                if(shouldCombo) 
                {
                stateMachine.SetNextState(new LightComboState());
                Debug.Log("Did light folow up");
                }    
                else
                 {
                stateMachine.SetNextStateToMain();
                 }
            }

    }
}
