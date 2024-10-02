using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class StateMachine 
{
    State CurrentState;

    static void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.OnUpdate();
        }
    }
    static void SetNextState(State newState)
    {
        CurrentState.OnExit();
        CurrentState = newState;
        CurrentState.OnEnter();
    }
}
