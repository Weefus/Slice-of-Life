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
    public float meleeRange;
    private float dist;
    public float rangedRange;
    public bool secondP;
    public int waveDelay;
    private string storage;
    public int holoDelay;


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
        
        //closestPlyr = getClosestPlayer(animator);
        //Debug.Log(animator.GetComponent<basicZombClass>().hp);
        //Debug.Log(animator.GetComponent<basicZombClass>().maxHP * .5);
        Debug.Log("endset");
        if (animator.GetComponent<basicZombClass>().hp <= (animator.GetComponent<basicZombClass>().maxHP * .5)) {
            animator.SetTrigger("50%<");
            
        }

        if (animator.GetComponent<basicZombClass>().hp <= 0) {
            animator.SetTrigger("0Hp");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<basicZombClass>().hp > 0)
        {//for each attack add its trigger to a string array if the closer player is within a area that generaly represents 
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
            if (secondP && animator.GetComponent<atkControler>().actionCount >= waveDelay)
            {
                attacks.Add("wave");
            }
            if (secondP && animator.GetComponent<atkControler>().actionsAfterHolo >= holoDelay)
            {
                attacks.Add("holo");
            }
            if (attacks.Count == 0)
            {
                animator.SetTrigger("move");
            }
            else
            {
                storage = attacks[Random.Range(0, attacks.Count)];
                if (!(storage.Equals("wave")))
                {
                    animator.GetComponent<atkControler>().act();
                }
                if (!(storage.Equals("holo")))
                {
                    animator.GetComponent<atkControler>().actHolo();
                }
                animator.SetTrigger(storage);
            }
        }
        else { }


        //the attack affected area

        //get a random element from the previously created array and set the triger for that element/attack
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
