using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public  class StateMachine 
{
    public string customName;
    private State mainStateType;
    public State CurrentState {  get; private set; }
    private State nextState;

     void Update()
    {
        if(nextState != null)
        {
            SetState(nextState);
        }
        if (CurrentState != null)
        {
            CurrentState.OnUpdate();
        }
    }
     void SetNextState(State newState)
    {
        CurrentState.OnExit();
        CurrentState = newState;
        CurrentState.OnEnter();
    }
}
