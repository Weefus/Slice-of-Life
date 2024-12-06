using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomProjTrack : MonoBehaviour
{
    private GameObject player;
    private float speed = 1.5f;
    public Collider2D coll;
    private float timer = 15f;
    private float damage = 5;
    private float playerDirct;
    private Rigidbody2D rigid;
    public TeamComponent team;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            if (player.transform.position.x > transform.position.x)
            {
                playerDirct = 1.0f;
            }
            else
            {
                playerDirct = -1.0f;
            }
             Vector2 missleDirection = (player.transform.position - this.transform.position).normalized;
            rigid.AddForce(missleDirection * speed);
        }
        else if (timer < 0) 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Player"))
        {
            
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
