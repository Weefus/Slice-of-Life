using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class mikuMelee : StateMachineBehaviour
{
    public float time = 0;
    public float hitTime;
    public float endTime;
    private Transform transform;
    public Vector3 loc;
    public Hitbox hitBox;
    private bool NotActive;
    public Hitbox cHitBox;
    public GameObject[] players;
    public int closestPlyr = 0;
    public float playerDirct = 1.0f;
    public float dist1;
    public float dist2;
    public float speed;
    private Rigidbody2D rigid;
    public float range;
    private float newLoc;
    private float distTraveled;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0;
        NotActive = true;
        players = GameObject.FindGameObjectsWithTag("Player");
        closestPlyr = getClosestPlayer(animator);
        rigid = animator.GetComponent<Rigidbody2D>();
        if (players[closestPlyr].transform.position.x > animator.GetComponent<Transform>().position.x)
        {
            playerDirct = 1.0f;
        }
        else
        {
            playerDirct = -1.0f;
        }
        newLoc = rigid.transform.position.x + (range * playerDirct);
        animator.GetComponent<Transform>().localScale = new Vector3(playerDirct, animator.GetComponent<Transform>().localScale.y, animator.GetComponent<Transform>().localScale.z);
        distTraveled = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = time + Time.deltaTime;

        if (time < endTime && time > hitTime && NotActive) {
            
            cHitBox = Instantiate(hitBox, new Vector3(animator.transform.position.x + (1 * animator.transform.localScale.x), animator.transform.position.y, animator.transform.position.z), hitBox.transform.rotation, animator.transform);
            NotActive = false;
            cHitBox.GetComponent<duration>().endtime = this.endTime;
        }

        if (time > endTime) {
            Destroy(cHitBox);
        }

        if (time > hitTime && distTraveled < range) {
            
            

            if (rigid.velocity == new Vector2(0, 0))
            {
                animator.GetComponent<Transform>().Translate(Vector3.right * speed * Time.deltaTime * playerDirct);
                distTraveled = distTraveled + speed * Time.deltaTime;
            }


        }






    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0f;

        if (players[closestPlyr].transform.position.x > animator.GetComponent<Transform>().position.x)
        {
            playerDirct = 1.0f;
        }
        else
        {
            playerDirct = -1.0f;
        }
        animator.GetComponent<Transform>().localScale = new Vector3(playerDirct, animator.GetComponent<Transform>().localScale.y, animator.GetComponent<Transform>().localScale.z);



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
