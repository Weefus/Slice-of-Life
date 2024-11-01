using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mikuRun : StateMachineBehaviour
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




    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        closestPlyr = getClosestPlayer(animator);
        rigid = animator.GetComponent<Rigidbody2D>();

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = time + Time.deltaTime;
        lastAtkSec = lastAtkSec + Time.deltaTime;
        closestPlyr = getClosestPlayer(animator);

        if (time > interval)
        {
            if (players[closestPlyr].transform.position.x > animator.GetComponent<Transform>().position.x)
            {
                playerDirct = 1.0f;
            }
            else
            {
                playerDirct = -1.0f;
            }
            time = 0f;
        }
            
        


        animator.GetComponent<Transform>().localScale = new Vector3(-playerDirct, 1, 1);



        if (rigid.velocity == new Vector2(0, 0))
        {
            animator.GetComponent<Transform>().Translate(Vector3.right * speed * Time.deltaTime * playerDirct);
        }

        if (Vector2.Distance(players[closestPlyr].transform.position, rigid.position) <= attackRange && players[closestPlyr].transform.position.y < vertBox)
        {
            animator.SetTrigger("leakMeleeT");
            lastAtkSec = 0;
        }
        else if (lastAtkSec >= 10.0f) {
            lastAtkSec = 0;
            animator.SetTrigger("rangedT");
            
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("leakMeleeT");
        animator.ResetTrigger("rangedT");
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
