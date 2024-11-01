using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StateMachine : MonoBehaviour
{
    public string customName;

    private State mainStateType;

    public State CurrentState { get; private set; }
    private State nextState;
    public State.AttackType currentAttack  {get;  set;}

    private void Start()
    {
        currentAttack = State.AttackType.none;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (nextState != null)
        {
            SetState(nextState);
        }

        if (CurrentState != null)
           // Debug.Log(currentAttack);
            CurrentState.OnUpdate(currentAttack);
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
    
}
