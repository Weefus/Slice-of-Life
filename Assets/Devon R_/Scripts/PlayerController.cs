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

    //Amount of force the jump uses
    public int jumpForce = 600;
    
    //Max speed player can go
    public float maxSpeed;
    //Used to get direction of key input, value of -1 or 1
    private float speedMulti;
    //The direct value from the input system
    private Vector2 direction;

    //bool facingleft = true;
    //SpriteRenderer myRenderer;
    //Animator mainAnim;
    //Animator idleAnim;
    //Animator sideAnim;

    //Chack to see if player has already used their jump/in-air
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
        //Checks if the player has reached a grounded state to get a jump back
        if ((collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform") && myRB.velocity.y <= 0)
        {
            //Player recovered their jump
            jumped = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Makes the player not be able to jump mid-air if they didn't already to get mid-air
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            //Player can't jump now
            jumped = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Can't move during knockback
        if (kb != null && kb.knockbackTimer > 0)
        {
            if (dash.isDashing)
            {
                kb.knockbackTimer = 0;
            }
            return;
        }

        //Can't move during a dash
        if (dash.isDashing)
        {
            Debug.Log("isDashing");
            return;
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

        //safety about not moving during dash
        if(!dash.isDashing)
            myRB.velocity = new Vector2(speedMulti * maxSpeed, myRB.velocity.y);

        //mainAnim.SetFloat("MoveSpeed", Mathf.Abs(move));

        //mainAnim.SetFloat("VerticalVelocity", Mathf.Abs(myRB.velocity.y));

        //switchSprite();

    }

    //Input method for basic movement (asd/arrows/sticks)
    public void Move(InputAction.CallbackContext value)
    {
        //Direction the input has been pressed in
        direction = value.ReadValue<Vector2>();

        //Input triggers
        if (value.started)
        {
            //Input to the right
            if(direction.x == 1)
            {
                //speed to the right
                speedMulti = 1f;
                //camera moves to the right of the player
                fPlayer.xOffset = 5f;
            }
            //Input to the left
            else
            {
                //speed to the left
                speedMulti = -1f;
                //camera moves to the left of the player
                fPlayer.xOffset = -5f;
            }

            //player flips as the direction changes
            myRB.transform.localScale = new Vector3(direction.x, 1, 1);
        }
        //Input was released
        else if (value.canceled)
        {
            //player shouldn't move with no input
            speedMulti = 0f;
        }
    }

    //Input method for the Jump
    public void Jump(InputAction.CallbackContext value)
    {
        //Input for jump started
        if (value.started && !jumped)
        {
            //Forces the player up like a jump
            gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().transform.TransformDirection(Vector3.up) * jumpForce);
            //Player has now used up their jump
            jumped = true;
        }
        //Input was let go
        else if (value.canceled)
        {

        }
    }

    //Input method for the dash
    public void Dash(InputAction.CallbackContext value)
    {
        //Input for dash started
        if (value.started && dash.canDash)
        {
            //Dash to the right if no direction
            if (direction == null || direction.x == 0)
            {
                StartCoroutine(dash.dashDuration(1f));
            }
            //Dashes in the direction of input otherwise
            else
            {
                StartCoroutine(dash.dashDuration(direction.x));
            }
        }
        //Input was let go
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