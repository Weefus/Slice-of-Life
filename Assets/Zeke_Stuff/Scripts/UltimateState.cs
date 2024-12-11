using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateState : MeleeBaseState
{
    private Transform playerTransform;
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        
    stateMachine.isFinisher = true;
        // attack
        attackIndex = 10;
        duration = 1.25f;
        animator.SetTrigger("Attack" + attackIndex);


        //  Debug.Log("Player Attack" + attackIndex + "fired!");

        playerTransform = stateMachine.transform;
        Vector3 effectPosition = playerTransform.position;
        effectPosition.y += 2.0f;

        Vector3 effectPosition2 = playerTransform.position;
        effectPosition2.y += 2.0f;
        

        GameObject buildupPrefab = stateMachine.getUltParticles();
        if (buildupPrefab != null && playerTransform != null)
        {

            GameObject effectInstance = GameObject.Instantiate(buildupPrefab, effectPosition, Quaternion.identity);
            effectInstance.transform.SetParent(playerTransform);

            GameObject.Destroy(effectInstance, duration);
        }

        GameObject buildupPrefab2 = stateMachine.getUltParticles2();
        if (buildupPrefab2 != null && playerTransform != null)
        {

            GameObject effectInstance2 = GameObject.Instantiate(buildupPrefab2, effectPosition2, Quaternion.identity);
            

            GameObject.Destroy(effectInstance2, duration);
        }
    }
    public override void OnUpdate(AttackType currentAttack, Attack1 attack1, Attack2 attack2)
    {
        base.OnUpdate(currentAttack, attack1, attack2);
        if (fixedtime >= duration)
        {
            //Debug.Log(fixedtime);
            
            stateMachine.player.decreaseUlt(100);
            stateMachine.SetNextStateToMain();
        }

    }
    public override void OnExit()
    {
        base.OnExit();
        attackWindow = 0;

    }
}
