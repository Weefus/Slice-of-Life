using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : StateMachineBehaviour
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
    private GameObject miku;
    private float side;
    private float angleOne = Mathf.PI / 6;
    private float angleTwo = Mathf.PI / 4;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        rigid = animator.GetComponent<Rigidbody2D>();
        miku = GameObject.FindGameObjectWithTag("Miku");

        side = miku.transform.localScale.x;

        //Method to spawn the projectiles
        Shotgun();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<basicZombClass>().hp <= (animator.GetComponent<basicZombClass>().maxHP * .5))
        {
            animator.SetTrigger("50%<");
            Debug.Log("trigger");
        }
        //Makes sure Miku doesn't move through the attack
        rigid.velocity = Vector3.zero;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void Shotgun()
    {
        //Spawns the three notes in an arc around Miku
        Instantiate(note, new Vector3(rigid.position.x + (1.5f * side), rigid.position.y, 0), Quaternion.identity);
        Instantiate(note, new Vector3((rigid.position.x + (Mathf.Cos(angleOne) * 1.5f * side)), Mathf.Sin(angleOne) + rigid.position.y, 0), Quaternion.identity);
        Instantiate(note, new Vector3((rigid.position.x + (Mathf.Cos(angleTwo) * side)), Mathf.Sin(angleTwo) + rigid.position.y, 0), Quaternion.identity);
    }
}
