using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBaseState : State
{
    //how long this state should be active
    public float duration;
    //cached animator component
    protected Animator animator;
    //bool to check whether or not the next hit should combo
    protected bool shouldCombo;
    //the attack index of the current attack
    protected int attackIndex;
    public override void OnEnter(StateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        animator = GetComponent<Animator>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetMouseButtonDown(0))
        {
            shouldCombo = true;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
