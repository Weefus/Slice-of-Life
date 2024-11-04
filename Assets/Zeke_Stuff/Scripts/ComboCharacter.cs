using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComboCharacter : MonoBehaviour
{
    // These Are the variables that are the modern
    protected State.AttackType currentAttack = State.AttackType.none;
   
    private StateMachine meleeStateMachine;

    private float maxCool = 1.0f;
    private float counter;

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
       // Debug.Log(counter);
        counter -= Time.deltaTime;
       // if (counter <= 0)
        
            meleeStateMachine.currentAttack = currentAttack;
            if (currentAttack == State.AttackType.light && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
            {
                meleeStateMachine.SetNextState(new LightEntryState());
            //Debug.Log("Started Combo");
            currentAttack = State.AttackType.none;
        }
            if (Input.GetMouseButton(1) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
            {
                meleeStateMachine.SetNextState(new HeavyEntryState());

            }
        
    }

    public void LightAttack(InputAction.CallbackContext value)
    {
        if (value.phase.Equals(InputActionPhase.Performed))
        {
            counter = maxCool;
            currentAttack = State.AttackType.light;
            Debug.Log("Clicked");
        }/* else if (value.phase.Equals(InputActionPhase.Canceled))
        {
            currentAttack = State.AttackType.none;
            Debug.Log("Stopped");
        }
        */
        /*
            if (value.performed && flag == true)
            {
            flag = false;
            currentAttack = State.AttackType.light;
                Debug.Log("Clicked");
                
            }
            else if (value.canceled)
            {
                currentAttack = State.AttackType.none;
                Debug.Log("Stopped");
                flag = true;
            }
        */
        
    }
}
