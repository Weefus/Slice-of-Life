using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public GameObject[] pickupPrefab;
    float vx;
    float vy;
    int rnd;
    void Start()
    {
        vx = transform.position.x;
        vy = transform.position.y;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Hitbox"))
        {
            rnd = Random.Range(0, 2);
            Debug.Log(rnd);
            Instantiate(pickupPrefab[rnd], new Vector3(vx, vy - 1, 0), Quaternion.identity);
        }
    }
}
