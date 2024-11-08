using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    private float side;
    private float angleOne = Mathf.PI / 6;
    private float angleTwo = Mathf.PI / 4;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        closestPlyr = GetClosestPlayer(animator);
        rigid = animator.GetComponent<Rigidbody2D>();

        if (players[closestPlyr].transform.position.x >= 0)
        {
            side = 1;
        }
        else
        {
            side = -1;
        }

        Shotgun();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        rigid.velocity = Vector3.zero;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void Shotgun()
    {
        Instantiate(note, new Vector3(rigid.position.x + (1.5f * side), rigid.position.y, 0), Quaternion.identity);
        Instantiate(note, new Vector3((rigid.position.x + (Mathf.Cos(angleOne) * 1.5f * side)), Mathf.Sin(angleOne) + rigid.position.y, 0), Quaternion.identity);
        Instantiate(note, new Vector3((rigid.position.x + (Mathf.Cos(angleTwo) * side)), Mathf.Sin(angleTwo) + rigid.position.y, 0), Quaternion.identity);
    }

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
