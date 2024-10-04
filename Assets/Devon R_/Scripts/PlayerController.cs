using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRB;
    public int jumpForce = 200;
    public int dashForce = 100;

    //move
    public float maxSpeed;
    //bool facingleft = true;
    //SpriteRenderer myRenderer;
    //Animator mainAnim;
    //Animator idleAnim;
    //Animator sideAnim;
    public bool jumped = true;
    //bool grounded = false;

    public GameObject Charsideprof;
    public GameObject Characteridle;



    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
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
        if (collision.gameObject.tag == "Ground" && myRB.velocity.y <= 0)
        {
            jumped = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        //just a quick check if you press space and if you're still in the air to prevent multiple jumps
        if (Input.GetKey(KeyCode.Space) && !jumped)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().transform.TransformDirection(Vector3.up) * jumpForce);
            jumped = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) && move >= 0) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().transform.TransformDirection(Vector3.right) * dashForce);
            Debug.Log("dash right");
        }

        if (Input.GetKey(KeyCode.LeftShift) && move < 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().transform.TransformDirection(Vector3.left) * dashForce);
            Debug.Log("dash left");
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
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        //mainAnim.SetFloat("MoveSpeed", Mathf.Abs(move));

        //mainAnim.SetFloat("VerticalVelocity", Mathf.Abs(myRB.velocity.y));

        //switchSprite();

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

    }*/

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