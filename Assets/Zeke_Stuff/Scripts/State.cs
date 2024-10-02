using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    // called at the beginning to initialize variables
    virtual void OnEnter();
    //called on every frame to update the state
    virtual void OnUpdate();
    //called at the end to clean up data
    virtual void OnExit();
}
