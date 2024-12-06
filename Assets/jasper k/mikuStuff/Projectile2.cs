using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile2 : StateMachineBehaviour
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

    public GameObject note;
    public float noteInterval = 0.5f;
    private GameObject miku;
    private float side;
    private float travelTime = 3f;
    private float attackTime;
    private float originalGravity;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        rigid = animator.GetComponent<Rigidbody2D>();
        miku = GameObject.FindGameObjectWithTag("Miku");

        side = miku.transform.localScale.x;

        //Takes away Miku's gravity to stay floating
        originalGravity = rigid.gravityScale;
        rigid.gravityScale = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        //Lets Miku move upwards for a interval
        if(time > travelTime)
        {
            rigid.velocity = Vector3.zero;
        }
        else
        {
            rigid.velocity = new Vector3(0, 0.75f, 0);
        }

        //Decides what height the notes should be
        int ranNote = Random.Range(0,3);

        //Spawns the selected note after the attack cooldown is past
        if (attackTime > noteInterval)
        {
            if (ranNote == 1)
            {
                Instantiate(note, new Vector3(rigid.position.x + (1.5f * side), 2, 0), Quaternion.identity);
            }
            else if (ranNote == 2)
            {
                Instantiate(note, new Vector3(rigid.position.x + (1.5f * side), 4, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(note, new Vector3(rigid.position.x + (1.5f * side), 6, 0), Quaternion.identity);
            }

            //resets the cooldown of the attack
            attackTime = 0;
        }

        //Increments the time for both moving and attacks
        time += Time.deltaTime;
        attackTime += Time.deltaTime;

        Debug.Log(time);
        if (time > 15.0f)
        {
            animator.SetTrigger("endRange");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Gives Miku gravity again
        rigid.gravityScale = originalGravity;
        time = 0;
        attackTime = 0;
    }
}
