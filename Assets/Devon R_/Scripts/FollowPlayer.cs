using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //speed of the camera follow
    public float speed = 10f;
    //offest of where the camera is on the x
    public float xOffset = 0f;
    //offest of where the camera is on the y
    public float yOffset = 0f;
    //offest of where the camera is on the z
    public float zOffset = 0f;
    //player to follow
    public Transform player;

    private void LateUpdate()
    {
        //New Position the camera will move towards
        Vector3 newPos = new Vector3(player.position.x + xOffset, player.position.y + yOffset, zOffset);
        //The camera moving to the new position
        transform.position = Vector3.Slerp(transform.position, newPos, speed * Time.deltaTime);
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
