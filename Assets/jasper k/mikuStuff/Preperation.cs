using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.GraphicsBuffer;

public class Preperation : StateMachineBehaviour
{
    public GameObject[] players;
    public int closestPlyr = 0;
    public float playerDirct = 1.0f;
    public float dist1;
    public float dist2;
    public float time = 0;
    public float interval;
    public float greyZone;
    public float speed;
    private Rigidbody2D rigid;
    public float attackRange = 1.5f;
    public float lastAtkSec = 0;
    public float vertBox = 1;

    private float side;
    private Vector2 target;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        players = GameObject.FindGameObjectsWithTag("Player");
        closestPlyr = GetClosestPlayer(animator);
        rigid = animator.GetComponent<Rigidbody2D>();

        //Gets closest player to miku and determines what side the attack should be towards
        if (players[closestPlyr].transform.position.x >= 0)
        {
            //player is on the right side or at zero
            side = 1;
           
        }
        else
        {
            //player is on the left side
            side = -1;
            
        }

        //Target position that miku will move towards
        target = new Vector2(18 * side, rigid.position.y);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<basicZombClass>().hp <= (animator.GetComponent<basicZombClass>().maxHP * .5))
        {
            animator.SetTrigger("50%<");
            Debug.Log("trigger");
        }
        //Makes sure Miku doesn't teleport to the other side
        if (Mathf.Abs(rigid.position.x) != 18)
        {
            //Miku moving towards the target position
            Vector2 newPos = Vector2.MoveTowards(rigid.position, target, speed * Time.fixedDeltaTime);
            //Updating position
            rigid.MovePosition(newPos);
        }
        
        //If miku is close to the position move on to the next stage
        if (Mathf.Approximately(Mathf.Round(rigid.position.x), side * 16) || Mathf.Abs(rigid.position.x) >= 16)
        {
            //Make up the distance that miku didn't make
            target.y = rigid.position.y;

            if(Mathf.Abs(rigid.position.x) != 18)
            {
                animator.GetComponent<Transform>().position = target;
            }
            else
            {
                side = -1 * animator.transform.localScale.x;
            }

            //Turns Miku around to get ready to fire
            animator.GetComponent<Transform>().localScale = new Vector3(-side, 1, 1);
            //Updates trigger
            animator.SetTrigger("rangedPT");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Updates triiger
        animator.ResetTrigger("rangedPT");
    }

    //Gets the closest player to Miku
    private int GetClosestPlayer(Animator animator)
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
