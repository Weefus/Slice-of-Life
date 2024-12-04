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
    Camera cam;
    Animator characterAnim;


    //Amount of force the jump uses
    public int jumpForce = 600;
    //A public variable to check the dashing state
    private bool isDashing;
    //Max speed player can go
    public float maxSpeed;
    //Used to get direction of key input, value of -1 or 1
    private float speedMulti;
    //The direct value from the input system
    private Vector2 direction;
    //if the player is in a boss fight
    private bool bossCam = false;
    //Check to see if player has already used their jump/in-air
    private bool jumped = false;
    //Ckeck to see if the player is moving
    public bool moving = false;
    //Check for the camera to start to return to center
    private bool reTurn = false;
    //Variable to increment towards the waitTime
    private float waiting = 0f;
    //Max wait time till camera moves
    private float waitTime = 2f;


    // Use this for initialization
    void Start()
    {
        cam = FindAnyObjectByType<Camera>();
        characterAnim = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody2D>();
        kb = GetComponent<KnockbackController>();
        dash = GetComponent<Dash>();
        fPlayer = cam.GetComponent<FollowPlayer>();
        if (GameObject.FindGameObjectWithTag("BossCamera") || cam == null)
        {
            bossCam = true;
        }
    }

    //you need to add a tag for your ground object for this to work properly
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if the player has reached a grounded state to get a jump back
        if ((collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform")) && myRB.velocity.y <= 0)
        {
            //Player recovered their jump
            jumped = false;
            characterAnim.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Makes the player not be able to jump mid-air if they didn't already to get mid-air
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            //Player can't jump now
            jumped = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isDashing = dash.isDashing;
        characterAnim.SetBool("isDashing", true);
        

        //Can't move during a dash
        if (isDashing)
        {
            return;
        }

        if (moving)
        {
            reTurn = false;
        }
        
        //safety about not moving during dash
        if(!isDashing)
            myRB.velocity = new Vector2(speedMulti * maxSpeed, myRB.velocity.y);


        if (kb.knockbackTimer > 0)
        {
            myRB.velocity = kb.kbForce - myRB.velocity;
        }

        //Lets the offest on the camera move in the direction of the player over time
        if (!bossCam && moving && transform.localScale.x > 0)
        {
            if (fPlayer.xOffset < fPlayer.maxXOffset)
            {
                //increases offset
                fPlayer.xOffset += 15 * Time.fixedDeltaTime;
            }
            else
            {
                //caps the offset
                fPlayer.xOffset = fPlayer.maxXOffset;
            }
        }
        //Lets the offest on the camera move in the direction of the player over time
        else if (!bossCam && moving && transform.localScale.x < 0)
        {
            if (fPlayer.xOffset > -fPlayer.maxXOffset)
            {
                //decreases offset
                fPlayer.xOffset -= 15 * Time.fixedDeltaTime;
            }
            else
            {
                //caps the offset
                fPlayer.xOffset = -fPlayer.maxXOffset;
            }
        }

        //When the player is standing still
        if(!bossCam && !moving)
        {
            //The wait function for the camera to move when the player is still
            if (!Mathf.Approximately(waiting, waitTime))
            {
                waiting += Time.deltaTime;
            }
            //camera can return to the center
            else
            {
                reTurn = true;
                waiting = 0f;
            }

            //return slowly from the right
            if (fPlayer.xOffset > 0 && reTurn)
            {
                fPlayer.xOffset -= 5 * Time.fixedDeltaTime;
            }
            //return slowly from the left
            else if(fPlayer.xOffset < 0 && reTurn)
            {
                fPlayer.xOffset += 5 * Time.fixedDeltaTime;
            }
            //fixes the offset to zero when it should be center
            else if(Mathf.Approximately(fPlayer.xOffset, 0))
            {
                fPlayer.xOffset = 0;
                reTurn = false;
            }
        }
    }

    //Input method for basic movement (asd/arrows/sticks)
    public void Move(InputAction.CallbackContext value)
    {
        //Direction the input has been pressed in
        direction = value.ReadValue<Vector2>();

        //Input triggers
        if (value.started)
        {
            characterAnim.SetBool("isMoving", true);
            //Input to the right
            if (direction.x == 1)
            {
                //speed to the right
                speedMulti = 1f;

                if (!bossCam)
                {
                    moving = true;
                }
            }
            //Input to the left
            else
            {
                //speed to the left
                speedMulti = -1f;

                if (!bossCam)
                {
                    moving = true;
                } 
            }

            //player flips as the direction changes
            myRB.transform.localScale = new Vector3(direction.x, 1, 1);
        }
        //Input was released
        else if (value.canceled)
        {
            characterAnim.SetBool("isMoving", false);
            //player shouldn't move with no input
            speedMulti = 0f;
            moving = false;
        }
    }

    //Input method for the Jump
    public void Jump(InputAction.CallbackContext value)
    {
        //Input for jump performed
        if (value.performed && !jumped && !isDashing)
        {
            //Forces the player up like a jump
            characterAnim.SetBool("isJumping", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().transform.TransformDirection(Vector3.up) * jumpForce);
            //Player has now used up their jump
            jumped = true;
            
        }
    }

    //Input method for the dash
    public void Dash(InputAction.CallbackContext value)
    {
        //Input for dash performed
        if (value.performed && dash.canDash)
        {
            //Player dashes the way they are facing
            StartCoroutine(dash.dashDuration(myRB.transform.localScale.x));
        }
    }

}