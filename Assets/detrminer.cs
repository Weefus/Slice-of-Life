using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detrminer : StateMachineBehaviour
{
    
    public float time = 0;
    private Transform transform;
    public float duration;
    public float range;
    public Vector3 loc;
    public Collider2D coll;





    public LayerMask mask;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        transform = animator.GetComponent<Transform>();
        loc = new Vector3(transform.position.x + transform.localScale.x * range, transform.position.y, transform.position.z);
        animator.ResetTrigger("leakMeleeT");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        time = time + Time.deltaTime;
        if (time >= duration) {

            coll = Physics2D.OverlapCircle(loc, range, mask); 

            if (coll != null) {
                animator.SetTrigger("leakMeleeT");
            }
            else {
                animator.SetTrigger("leakRangedT");
            }
            

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("leakRangedT");
        animator.ResetTrigger("leakMeleeT");
        time = 0f;
    }

    

    


}
