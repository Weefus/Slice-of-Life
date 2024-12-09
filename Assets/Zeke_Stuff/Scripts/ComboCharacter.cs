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
    private bool ultPress;
    private float counter;
    public Player player;

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
            if (currentAttack == State.AttackType.heavy && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
            {
                meleeStateMachine.SetNextState(new HeavyEntryState());
            currentAttack = State.AttackType.none;
            }
            if (ultPress && player.ult == player.maxUlt)
        {
            meleeStateMachine.SetNextState(new UltimateState());
        }
        
    }

    public void LightAttack(InputAction.CallbackContext value)
    {
        if (value.phase.Equals(InputActionPhase.Performed))
        {
            counter = maxCool;
            currentAttack = State.AttackType.light;
           // Debug.Log("Clicked");
        } else if (value.phase.Equals(InputActionPhase.Canceled))
        {
            currentAttack = State.AttackType.none;
           // Debug.Log("Stopped");
        }
        
    }
    public void HeavyAttack(InputAction.CallbackContext value)
    {
        if (value.phase.Equals(InputActionPhase.Performed))
        {
            counter = maxCool;
            currentAttack = State.AttackType.heavy;
            //Debug.Log("Clicked");
        }
        else if (value.phase.Equals(InputActionPhase.Canceled))
        {
            currentAttack = State.AttackType.none;
           // Debug.Log("Stopped");
        }

    }
    public void Ultimate(InputAction.CallbackContext value)
    {
        if (value.phase.Equals(InputActionPhase.Performed))
        {
          ultPress = true;
        }
        else if (value.phase.Equals(InputActionPhase.Canceled))
        {
            ultPress   =  false;
        }

    }
}
