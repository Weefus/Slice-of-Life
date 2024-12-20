using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveAtk : StateMachineBehaviour
{

    public GameObject wave;
    public GameObject cWave;
    private bool canAtk;
    private float time;
    public float atkStartTime;
    public float atkEndTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0;
        canAtk = true;
        animator.GetComponent<atkControler>().reset();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = time + Time.deltaTime;
        if (canAtk)
        {
            cWave = Instantiate(wave, new Vector3(0, -2.5f, 4), wave.transform.rotation);
            canAtk = false;
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
}
