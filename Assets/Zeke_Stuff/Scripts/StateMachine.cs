using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StateMachine : MonoBehaviour
{
    public string customName;

    private State mainStateType;

    public bool isFinisher;
    public State CurrentState { get; private set; }
    private State nextState;
    public State.AttackType currentAttack  {get;  set;}
    public State.Attack1 attack1 {get; set;}
    public State.Attack2 attack2 {get; set;}
    private float cooldown;

    private void Start()
    {
        currentAttack = State.AttackType.none;
        attack1 = State.Attack1.none;
        attack2 = State.Attack2.none;
    }
    // Update is called once per frame
    void Update()
    {
       cooldown -= Time.deltaTime;

        if (nextState != null)
        {
            SetState(nextState);
        }

        if (CurrentState != null)
           // Debug.Log(currentAttack);
            CurrentState.OnUpdate(currentAttack, attack1, attack2);
    }

    private void SetState(State _newState)
    {
        nextState = null;
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }
        CurrentState = _newState;
        CurrentState.OnEnter(this);
        Debug.Log(CurrentState.ToString());
    }

    public void SetNextState(State _newState)
    {
        if (_newState != null)
        {
            nextState = _newState;
            currentAttack = State.AttackType.none;
        }
    }

    private void LateUpdate()
    {
        if (CurrentState != null)
            CurrentState.OnLateUpdate();
    }

    private void FixedUpdate()
    {
        if (CurrentState != null)
            CurrentState.OnFixedUpdate();
    }

    public void SetNextStateToMain()
    {
        nextState = mainStateType;
        currentAttack = State.AttackType.none;
    }

    private void Awake()
    {
        if (mainStateType == null)
        {
            if (customName == "Combat")
            {
                mainStateType = new IdleCombatState();
            }
        }
    
    SetNextStateToMain();

    }


    private void OnValidate()
    {
        if (mainStateType == null)
        {
            if (customName == "Combat")
            {
                mainStateType = new IdleCombatState();
            }
        }
    }

    public void SpamCooldown()
    {
        Debug.Log(cooldown);
        cooldown = 0.25f;
        if (cooldown < 0)
        {
            SetNextStateToMain();
        }
    }
    
}
