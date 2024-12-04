using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hologram : StateMachineBehaviour
{
    public GameObject hologramSource;
    private float time;
    private float startTime;
    private float endTime;
    private float initalHp;
    public Vector3 loc1;
    public Vector3 loc2;
    public Vector3 loc3;
    public Vector3 loc4;
    public bool hasntSpawd;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0;
        initalHp = animator.GetComponent<basicZombClass>().hp;
        hasntSpawd = true;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = time + Time.deltaTime;
        if (time >= startTime && hasntSpawd) {
            Instantiate(hologramSource, loc1, hologramSource.transform.rotation);
            Instantiate(hologramSource, loc2, hologramSource.transform.rotation);
            Instantiate(hologramSource, loc3, hologramSource.transform.rotation);
            Instantiate(hologramSource, loc4, hologramSource.transform.rotation);
            hasntSpawd = false;
        }
        animator.GetComponent<basicZombClass>().hp = initalHp;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<atkControler>().resetHoloCount();
    }
}
