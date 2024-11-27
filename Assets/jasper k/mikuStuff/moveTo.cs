using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTo : StateMachineBehaviour
{
    public Vector3 target;
    public GameObject[] players;
    public int closestPlyr = 0;
    public float playerDirct = 1.0f;
    public float dist1;
    public float dist2;
    private Vector3 direction;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.GetComponent<Rigidbody2D>().gravityScale = 0;
        


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 position = animator.GetComponent<Transform>().position;
        direction = (target - animator.GetComponent<Transform>().position).normalized;
        animator.GetComponent<Transform>().position = animator.GetComponent<Transform>().position + (direction * speed * Time.deltaTime);
        if (target.x + 1 >= position.x && target.x - 1 <= position.x && target.y + 1 > position.y && target.y - 1 < position.y)
        {
            animator.SetTrigger("next");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("next");
    }

    private int getClosestPlayer(Animator animator)
    {


        if (players.Length <= 1)
        {
            return 0;
        }

        dist1 = Mathf.Abs(players[1].transform.position.x - animator.GetComponent<Transform>().position.x);
        dist2 = Mathf.Abs(players[0].transform.position.x - animator.GetComponent<Transform>().position.x);


        if (dist1 > dist2)
        {
            return 0;
        }
        else { return 1; }
    }


}
