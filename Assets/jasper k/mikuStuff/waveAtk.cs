using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveAtk : StateMachineBehaviour
{

    public GameObject wave;
    public GameObject cWave;
    private float time;
    public float atkStartTime;
    public float atkEndTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = time + Time.deltaTime;
        if (time > atkStartTime && time < atkEndTime)
        {
            cWave = Instantiate(wave, new Vector3(0, 1.5f, 0), wave.transform.rotation);
        }
        if (time > atkEndTime) {
            Destroy(cWave);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
}
