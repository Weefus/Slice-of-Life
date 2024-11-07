using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody2D rigid;
    GameObject miku;
    public float speed = 10;
    private float speedMulti;
    private float angle;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        miku = GameObject.FindGameObjectWithTag("Miku");

        if (rigid.position.x >= 0)
        {
            speedMulti = -1;
        }
        else
        {
            speedMulti = 1;
        }

        angle = Mathf.Acos((Mathf.Abs(rigid.position.x) - 9) / (Mathf.Abs(speedMulti) * 1.5f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(speedMulti == 1)
        {
            rigid.velocity = new Vector2(speed * speedMulti * -Mathf.Cos(angle), speed * speedMulti * Mathf.Sin(angle));
        }
        else
        {
            rigid.velocity = new Vector2(speed * speedMulti * -Mathf.Cos(angle), speed * speedMulti * -Mathf.Sin(angle));
        }
        

        if (Mathf.Abs(rigid.position.x) > 10 || rigid.position.y > 20)
        {
            Destroy(gameObject);
        }
    }
}
