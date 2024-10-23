using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public GameObject pickupPrefab;
    float vx;
    float vy;
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
            Instantiate(pickupPrefab, new Vector3(vx,vy-1,0), Quaternion.identity);
            Debug.Log(vx);
            Debug.Log(vy);
        }
    }
}
