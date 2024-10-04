using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntryState : MonoBehaviour
{
    public override void OnEnter()
    {
        base.OnEnter(stateMachine);

        State nextState = (State)new LightEntryState();
        stateMachine.SetNextState(nextState);
    }
}
