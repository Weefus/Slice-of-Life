using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class zombieMove : MonoBehaviour
{
    private GameObject[] players;
    private float playerDirct = 1.0f;
    public float speedBase;
    private int closestPlyr = 0;
    private float dist1;
    private float dist2;
    private float time = 0;
    public float interval;
    public float greyZone;
    private float speed;
    public float speedVariation;
    private Rigidbody2D rigid;
    public bool canMove;
    public KnockbackController kb;
    basicZombClass zomb;
    // Start is called before the first frame update
    void Start()
    {
        zomb = GetComponent<basicZombClass>();
        kb = GetComponent<KnockbackController>();
        speed = speedBase + Random.Range(-speedVariation, speedVariation);
        players = GameObject.FindGameObjectsWithTag("Player");
        closestPlyr = getClosestPlayer();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (zomb.hp <= 0)
        {
            return;
        }

        time = time + Time.deltaTime;
        closestPlyr = getClosestPlayer();

        if (time > interval) { 
            if (players[closestPlyr].transform.position.x > transform.position.x)
            {
                playerDirct = 1.0f;
            }
            else {
                playerDirct = -1.0f;
            }
            time = 0f;
        }

        if (rigid.velocity == new Vector2(0,0) && canMove) {
            transform.localScale = new Vector3(-playerDirct, transform.localScale.y, transform.localScale.z);
            transform.Translate(Vector3.right * speed * Time.deltaTime * playerDirct);
        }
    }

    private int getClosestPlayer()
    {
        

        if (players.Length <= 1)
        {
            return 0;
        }

        dist1 = Mathf.Abs(players[1].transform.position.x - transform.position.x);
        dist2 = Mathf.Abs(players[0].transform.position.x - transform.position.x);

        if (Mathf.Abs(dist1 - dist2) > greyZone)
        {
            if (dist1 > dist2)
            {
                return 0;
            }
            else return 1;
        }
        else { return closestPlyr; }
        
    }
}
