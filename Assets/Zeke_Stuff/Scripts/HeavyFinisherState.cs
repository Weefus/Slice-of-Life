using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyFinisherState : MeleeBaseState
{
    private Transform playerTransform;
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        stateMachine.isFinisher = true;
        // attack
        attackIndex = 6;
        duration = 1.0f;
        animator.SetTrigger("Attack" + attackIndex);
        // Debug.Log("Player Attack" + attackIndex + "fired!");

        playerTransform = stateMachine.transform;
        Vector3 effectPosition = playerTransform.position;
        effectPosition.y += 2.0f;

    GameObject effectPrefab = stateMachine.getFinisherParticles();
        if (effectPrefab != null && playerTransform != null)
        {
            
            GameObject effectInstance = GameObject.Instantiate(effectPrefab, effectPosition, Quaternion.identity);
            effectInstance.transform.SetParent(playerTransform);
            // Optionally destroy the effect after a duration
            GameObject.Destroy(effectInstance, duration);
        }

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
        if (fixedtime >= duration)
        {
            attack1 = Attack1.none;
            attack2 = Attack2.none;
            stateMachine.SetNextStateToMain();
        }

    }
    public override void OnExit()
    {
        base.OnExit();
        AttackPressedTimer = 0;
      
    }
}
