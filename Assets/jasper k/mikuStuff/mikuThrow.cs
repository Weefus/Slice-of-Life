using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mikuThrow : StateMachineBehaviour
{
    public leak leakf;
    public GameObject leakb;
    public Vector3 loc;
    private Transform transform;
    private float time;
    public float startT;
    private bool hasThrown;
    public float dmg;
    public leak leek;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.GetComponent<Transform>();
        time = 0;
        hasThrown = false;
        animator.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);



    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = time + Time.deltaTime;
        if (animator.GetComponent<basicZombClass>().hp <= (animator.GetComponent<basicZombClass>().maxHP * .5))
        {
            animator.SetTrigger("50%<");
            Debug.Log("trigger");
        }

        if (time > startT && !hasThrown) {
            loc = new Vector3(transform.position.x + (transform.localScale.x * 1.5f), transform.position.y, 0);

            leek = Instantiate(leakf, loc, leakf.transform.rotation);
            leek.damageAmt = dmg;
            hasThrown = true;
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
