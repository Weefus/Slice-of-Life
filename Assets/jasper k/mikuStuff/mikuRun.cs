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
    public float meleeRange;
    public float rangedRange;
    private float dist;
    //public float attackRange = 1.5f;
    //public float lastAtkSec = 0;
    //public float vertBox = 1;




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
        if (animator.GetComponent<basicZombClass>().hp <= (animator.GetComponent<basicZombClass>().maxHP * .5))
        {
            animator.SetTrigger("50%<");
            
        }
        time = time + Time.deltaTime;
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


        

        animator.GetComponent<Transform>().localScale = new Vector3(playerDirct, animator.GetComponent<Transform>().localScale.y, animator.GetComponent<Transform>().localScale.z);



        if (rigid.velocity == new Vector2(0, 0))
        {
            animator.GetComponent<Transform>().Translate(Vector3.right * speed * Time.deltaTime * playerDirct);
            if (Mathf.Abs(players[closestPlyr].transform.position.x - rigid.GetComponent<Transform>().position.x) < 5) {
                animator.SetTrigger("end move");
                animator.SetTrigger("leakMeleeT");
            }
        }

        //if (Mathf.Abs(players[closestPlyr].transform.position.x - animator.GetComponent<Transform>().transform.position.x) <= attackRange && players[closestPlyr].transform.position.y <= -3.25)
        //{
        //    animator.SetTrigger("leakMeleeT");
        //    lastAtkSec = 0;
        //}
        //else if (lastAtkSec >= 5.0f) {
        //    lastAtkSec = 0;
        //    animator.SetTrigger("rangedT");
            
        //}

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("leakMeleeT");
        animator.ResetTrigger("rangedT");
        time = 0f;
        List<string> attacks = new List<string>();
        dist = players[closestPlyr].transform.position.x - rigid.transform.position.x;
        if ((dist <= meleeRange && dist >= 0) || (dist >= -meleeRange && dist <= 0))
        {
            attacks.Add("leakMeleeT");
        }
        if ((dist <= rangedRange && dist >= 0) || (dist >= -rangedRange && dist <= 0))
        {
            attacks.Add("rangedT");
        }
        if (attacks.Count == 0)
        {
            animator.SetTrigger("move");
        }
        else
        {
            animator.SetTrigger(attacks[Random.Range(0, attacks.Count)]);
        }
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
