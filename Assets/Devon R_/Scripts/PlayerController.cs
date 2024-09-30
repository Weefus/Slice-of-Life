using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    //private bool isOnGround = true;
    private float horizontalInput;
    private Rigidbody2D playerRb;
    private Vector2 movement;
    private Vector2 jump;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        movement = new Vector2(horizontalInput, 0);
        jump = new Vector2(0, jumpForce);

        playerRb.velocity = movement * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(jump, ForceMode2D.Impulse);
        }
    }
}
