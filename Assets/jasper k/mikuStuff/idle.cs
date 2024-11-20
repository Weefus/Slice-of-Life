using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idle : StateMachineBehaviour
{
    public GameObject[] players;
    public int closestPlyr = 0;
    public float playerDirct = 1.0f;
    public float dist1;
    public float dist2;
    public float interval;
    public float greyZone;
    private Rigidbody2D rigid;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        closestPlyr = getClosestPlayer(animator);
        rigid = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        closestPlyr = getClosestPlayer(animator);
        if (animator.GetComponent<basicZombClass>().hp <= (animator.GetComponent<basicZombClass>().maxHP * .5)) {
            animator.SetTrigger("50%<");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private int getClosestPlayer(Animator animator)
    {


        if (players.Length <= 1)
        {
            return 0;
        }

        dist1 = Mathf.Abs(players[1].transform.position.x - animator.GetComponent<Transform>().position.x);
        dist2 = Mathf.Abs(players[0].transform.position.x - animator.GetComponent<Transform>().position.x);

        if (Mathf.Abs(dist1 - dist2) > greyZone)
        {
            if (dist1 > dist2)
            {
                return 0;
            }
            else return 1;
        }
        else { return closestPlyr; }

    }
}
