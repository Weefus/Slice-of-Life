using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDeath : MonoBehaviour
{
    public Player player;
    public float vx;
    public float vy;
    // Start is called before the first frame update
    void Start()
    {
        player = (Player)FindObjectOfType(typeof(Player));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.decreaseHP(10);
            player.transform.position = new Vector3(vx, vy, 4.88f);
        }
    }
}
