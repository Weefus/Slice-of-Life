using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomProjTrack : MonoBehaviour
{
    private GameObject player;
    private float speed = 3.0f;
    public Collider2D coll;
    private float timer = 15f;
    private float damage = 5;
    private float playerDirct;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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
            transform.Translate(Vector3.right * speed  * playerDirct);
            transform.Translate(Vector3.up * speed * playerDirct);
        }
        else if (timer < 0) 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            coll.GetComponent<Hurtbox>().DealDamage(damage);
            
            Destroy(gameObject);
        }
    }
}
