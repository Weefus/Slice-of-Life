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
    public bool moving = false;


    // Use this for initialization
    void Start()
    {
        characterAnim = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody2D>();
        kb = GetComponent<KnockbackController>();
        dash = GetComponent<Dash>();
        fPlayer = cam.GetComponent<FollowPlayer>();
        if (cam.CompareTag("BossCamera") || cam == null)
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
        
        //safety about not moving during dash
        if(!isDashing)
            myRB.velocity = new Vector2(speedMulti * maxSpeed, myRB.velocity.y);


        if (kb.knockbackTimer > 0)
        {
            myRB.velocity = kb.kbForce - myRB.velocity;

            Debug.Log(myRB.velocity);
        }

        if (!bossCam && moving && transform.localScale.x > 0)
        {
            if (fPlayer.xOffset < fPlayer.maxXOffset)
            {
                fPlayer.xOffset += 15 * Time.fixedDeltaTime;
            }
            else
            {
                fPlayer.xOffset = fPlayer.maxXOffset;
            }
        }
        else if (!bossCam && moving && transform.localScale.x < 0)
        {
            if (fPlayer.xOffset > -fPlayer.maxXOffset)
            {
                fPlayer.xOffset -= 15 * Time.fixedDeltaTime;
            }
            else
            {
                fPlayer.xOffset = -fPlayer.maxXOffset;
            }
        }

        if(!bossCam && !moving)
        {
            if (fPlayer.xOffset > 0)
            {
                fPlayer.xOffset -= 5 * Time.fixedDeltaTime;
            }
            else if(fPlayer.xOffset < 0)
            {
                fPlayer.xOffset += 5 * Time.fixedDeltaTime;
            }
            else if(Mathf.Approximately(fPlayer.xOffset, 0))
            {
                fPlayer.xOffset = 0;
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
                //camera moves to the right of the player
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
                //camera moves to the left of the player

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
    }

}