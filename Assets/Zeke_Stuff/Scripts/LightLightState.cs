using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLightState : MeleeBaseState
{

    private Transform playerTransform;
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        
        // attack
        attackIndex = 2;
        duration = 0.65f;
        multInput = duration * 2;
        animator.SetTrigger("Attack" + attackIndex);
        playerTransform = stateMachine.transform;
        Vector3 effectPosition = playerTransform.position;
        effectPosition.y += 2.0f;

        GameObject buildupPrefab = stateMachine.getBuildupParticles();
        if (buildupPrefab != null && playerTransform != null)
        {

            GameObject effectInstance = GameObject.Instantiate(buildupPrefab, effectPosition, Quaternion.identity);
            effectInstance.transform.SetParent(playerTransform);

            GameObject.Destroy(effectInstance, duration);
        }


    }
    public override void OnUpdate(AttackType currentAttack, Attack1 attack1, Attack2 attack2)
    {
        base.OnUpdate(currentAttack, attack1, attack2);

       attack2 = Attack2.light;
        if (fixedtime >= duration)
        {
         //   Debug.Log("fixed time" +fixedtime + "should combo" + shouldCombo );
            if (currentAttack == AttackType.light)
            {
                stateMachine.SetNextState(new LightFinisherState());
                
            } else if (currentAttack == AttackType.heavy)
            {
                stateMachine.SetNextState(new  HeavyFinisherState());
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
        //AttackPressedTimer = 0;
    }
}
