using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRB;
    KnockbackController kb;
    Dash dash;
    FollowPlayer fPlayer;
    public Camera cam;

    public int jumpForce = 600;
    
    //move
    public float maxSpeed;
    private float speedMulti;
    private Vector2 direction;
    //bool facingleft = true;
    //SpriteRenderer myRenderer;
    //Animator mainAnim;
    //Animator idleAnim;
    //Animator sideAnim;
    public bool jumped = false;
    //bool grounded = true;

    public GameObject Charsideprof;
    public GameObject Characteridle;

    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        kb = GetComponent<KnockbackController>();
        dash = GetComponent<Dash>();
        fPlayer = cam.GetComponent<FollowPlayer>();
        // myRenderer = GetComponent<SpriteRenderer>();

        //mainAnim = GetComponent<Animator>();
        //idleAnim = Characteridle.GetComponent<Animator>();
        //sideAnim = Charsideprof.GetComponent<Animator>();


        //Variables needed for Animator for script to work
        //Bool Moving
        //Bool IsGrounded

        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        Quaternion flipRotation = Quaternion.Euler(0, 180, 0);
    }

    //you need to add a tag for your ground object for this to work properly
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform") && myRB.velocity.y <= 0)
        {
            jumped = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            jumped = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (kb != null && kb.knockbackTimer > 0)
        {
            return;
        }

        if (dash.isDashing)
        {
            Debug.Log("isDashing");
            return;
        }
        
        if (direction.x != 0)
        {
            myRB.transform.localScale = new Vector3(direction.x, 1, 1); 
        }
        //mainAnim.SetBool("IsGrounded", !jumped);
        //idleAnim.SetBool("IsGrounded", !jumped);
        //sideAnim.SetBool("IsGrounded", !jumped);



        /*if (move > 0 && !facingleft)
        {
            Flip();
        }
        else if (move < 0 && facingleft)
        {
            Flip();
        }
        if (move != 0)
        {
            mainAnim.SetBool("Moving", true);
            idleAnim.SetBool("Moving", true);
            sideAnim.SetBool("Moving", true);

        }
        else if (move == 0)
        {
            mainAnim.SetBool("Moving", false);
            idleAnim.SetBool("Moving", false);
            sideAnim.SetBool("Moving", false);

        }*/

        if(!dash.isDashing)
            myRB.velocity = new Vector2(speedMulti * maxSpeed, myRB.velocity.y);

        //mainAnim.SetFloat("MoveSpeed", Mathf.Abs(move));

        //mainAnim.SetFloat("VerticalVelocity", Mathf.Abs(myRB.velocity.y));

        //switchSprite();

    }

    public void Move(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();

        if (value.started)
        {
            if(direction.x == 1)
            {
                speedMulti = 1f;
                fPlayer.xOffset = 5f;
            }
            else
            {
                speedMulti = -1f;
                fPlayer.xOffset = -5f;
            }
        }
        else if (value.canceled)
        {
            speedMulti = 0f;
        }
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (value.started && !jumped)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().transform.TransformDirection(Vector3.up) * jumpForce);
            jumped = true;
        }
        else if (value.canceled)
        {

        }
    }

    public void Dash(InputAction.CallbackContext value)
    {
        if (value.started && dash.canDash)
        {
            if (direction == null || direction.x == 0)
            {
                StartCoroutine(dash.dashDuration(1f));
            }
            else
            {
                StartCoroutine(dash.dashDuration(direction.x));
            }
        }
        else if (value.canceled)
        {
            
        }

    }

    /*void Flip()
    {
        if (!facingleft)
        {
            transform.Rotate(0, 180, 0);
        }

        if (facingleft)
        {
            transform.Rotate(0, 180, 0);
        }

        facingleft = !facingleft;

    }

    /*void switchSprite()
    {

        bool isMoving = mainAnim.GetBool("Moving");
        bool isGrounded = mainAnim.GetBool("IsGrounded");


        if (!mainAnim.GetBool("Moving") && mainAnim.GetBool("IsGrounded"))
        {

            Charsideprof.SetActive(false);

            Characteridle.SetActive(true);


        }
        else
        {

            Characteridle.SetActive(false);

            Charsideprof.SetActive(true);

        }

    }*/


}