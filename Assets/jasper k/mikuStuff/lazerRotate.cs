using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerRotate : MonoBehaviour
{
    public GameObject target;
    public GameObject[] players;
    public int closestPlyr = 0;
    public float playerDirct = 1.0f;
    public float dist1;
    public float dist2;
    private Vector3 direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        closestPlyr = getClosestPlayer();
        target = players[closestPlyr];
        transform.LookAt(target.transform, Vector3.up);
        if (target.transform.position.x > transform.position.x) {
            speed = speed * -1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        if (transform.position.y <= -1) {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag + "lazer");
        if (gameObject.tag != col.tag && col.tag != "Miku" && col.tag != "BossCamera")
        {

            Debug.Log("hit something");
            Destroy(gameObject);
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


        if (dist1 > dist2)
        {
            return 0;
        }
        else { return 1; }
    }
}
