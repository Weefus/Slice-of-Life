using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{
    private StateMachine lightStateMachine;

    [SerializeField] public Collider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        lightStateMachine = GetComponent < StateMachine >();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && lightStateMachine.CurrentState.GetType() == typeof (IdleCombatState)) {
            lightStateMachine.SetNextState(new GroundEntryState());
         }
    }
