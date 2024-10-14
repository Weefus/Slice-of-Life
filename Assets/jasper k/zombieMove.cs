using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class zombieMove : MonoBehaviour
{
    public GameObject[] players;
    public float playerDirct = 1.0f;
    public float speed;
    public int closestPlyr;
    public float dist1;
    public float dist2;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        closestPlyr = getClosestPlayer();
        if (players[closestPlyr].transform.position.x > transform.position.x)
        {
            playerDirct = 1.0f;
        }
        else {
            playerDirct = -1.0f;
        }

        transform.localScale = new Vector3(playerDirct, 1, 1);
        transform.Translate(Vector3.right * speed * Time.deltaTime * playerDirct);
        
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
        else return 1;
    }
}
