using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //speed of the camera follow
    public float speed = 10f;
    public float maxXOffset = 0;
    //offest of where the camera is on the x
    public float xOffset = 0f;
    //offest of where the camera is on the y
    public float yOffset = 0f;
    //offest of where the camera is on the z
    public float zOffset = 0f;
    //player to follow
    public Player player;
    private PlayerController cPlayer;
    public float deadZone = 5.0f;
    private Vector3 playerPos;
    private Vector3 camPos;
    
    private void Start()
    {
        player = (Player)FindObjectOfType(typeof(Player));
        cPlayer = player.GetComponent<PlayerController>();
    }
    private void LateUpdate()
    {
        if (player != null)
        {
            playerPos = player.transform.position;
            camPos = transform.position;

            if (CanMove() && !this.CompareTag("BossCamera"))
            {
                //New Position the camera will move towards
                Vector3 newPos = new Vector3(playerPos.x + xOffset, playerPos.y + yOffset, zOffset);
                //The camera moving to the new position
                transform.position = Vector3.Slerp(camPos, newPos, speed * Time.deltaTime);
            }
        }
    }

    private bool CanMove()
    {
       if((camPos.x - playerPos.x) - xOffset > deadZone || (camPos.x - playerPos.x) - xOffset < -deadZone)
       {
            return true;
       }
       else if ((camPos.y - playerPos.y) - yOffset > deadZone || (camPos.y - playerPos.y) - yOffset < -deadZone)
       {
            return true;
       }
       else if (!cPlayer.moving)
       {
           return true;
       }
       else
       {
           return false;
       }       
    }

    //Old 

    /*public GameObject followPlayer;
    public Vector2 followOffset = new Vector2(4f, 0.3f);
    public float speed = 10f;
    public float cameraSectionX;
    private Vector2 threshold;
    private Rigidbody2D rb;
    
    // Use this for initialization
    void Start()
    {
        threshold = calculateThreshold();
        rb = followPlayer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Vector2 follow = followPlayer.transform.position;
       float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
       float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        if(Mathf.Abs(xDifference) >= threshold.x)
        {
            newPosition.x = follow.x;
        }
        if (Mathf.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }

        float moveSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }

    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(new Vector3(transform.position.x + cameraSectionX, transform.position.y, transform.position.z), new Vector3(border.x * 2, border.y * 2, 1));
    }*/
}
