using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 10;
    private float speedMulti;
    private float angle;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        if (rigid.position.x >= 0)
        {
            speedMulti = -1;
        }
        else
        {
            speedMulti = 1;
        }

        //Gets the angle of the note's initial position
        angle = Mathf.Acos((Mathf.Abs(rigid.position.x) - 18) / (speedMulti * 1.5f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Continues on the angle towards which side miku was facing
        if(speedMulti == 1)
        {
            rigid.velocity = new Vector2(speed * speedMulti * -Mathf.Cos(angle), speed * speedMulti * Mathf.Sin(angle));
        }
        else
        {
            rigid.velocity = new Vector2(speed * speedMulti * Mathf.Cos(angle), speed * speedMulti * -Mathf.Sin(angle));
        }
        
        //If the note goes out side of the arena, it's destroyed
        if (Mathf.Abs(rigid.position.x) > 20 || rigid.position.y > 20)
        {
            Destroy(gameObject);
        }
    }
}
