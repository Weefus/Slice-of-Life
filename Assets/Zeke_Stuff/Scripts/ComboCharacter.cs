using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComboCharacter : MonoBehaviour
{
    // These Are the variables that are the modern
    protected State.AttackType currentAttack = State.AttackType.none;

    private StateMachine meleeStateMachine;

    [SerializeField] public Collider2D hitbox;
    [SerializeField] public GameObject Hiteffect;

    // Start is called before the first frame update
    void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();
        Debug.Log(currentAttack);
    }

    // Update is called once per frame
    void Update()
    {
        meleeStateMachine.currentAttack = currentAttack;
       if (currentAttack == State.AttackType.light && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
       {
            meleeStateMachine.SetNextState(new LightEntryState());
            //Debug.Log("Started Combo");
            
       }
        if (Input.GetMouseButton(1) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            meleeStateMachine.SetNextState(new HeavyEntryState());
           
        }
    }

    public void LightAttack(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            currentAttack = State.AttackType.light;
            Debug.Log("Clicked");
            
        }
        else if (value.canceled)
        {
            currentAttack = State.AttackType.none;
            Debug.Log("Stopped");
        }
    }
}
