using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComboCharacter : MonoBehaviour
{
    // These Are the variables that are the modern
    public State.AttackType currentAttack;

    private StateMachine meleeStateMachine;

    [SerializeField] public Collider2D hitbox;
    [SerializeField] public GameObject Hiteffect;

    // Start is called before the first frame update
    void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
       if (lightAttack && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
       {
            meleeStateMachine.SetNextState(new LightEntryState());
             
       }
        if (Input.GetMouseButton(1) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            meleeStateMachine.SetNextState(new HeavyEntryState());
           
        }
    }

    public void LightAttack(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            cur
        }
        else if (value.canceled)
        {
            lightAttack = false;
        }
    }
}
