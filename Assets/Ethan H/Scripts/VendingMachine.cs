using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public GameObject[] pickupPrefab;
    public SpriteRenderer sr;
    public Sprite sprite;
    float vx;
    float vy;
    float vz;
    int hp = 1;
    int rnd;
    bool isEmpty = false;
    void Start()
    {
        vx = transform.position.x;
        vy = transform.position.y;
        vz = transform.position.z;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Hitbox") && isEmpty == false)
        {
            rnd = Random.Range(0, 2);
            Instantiate(pickupPrefab[rnd], new Vector3(vx, vy - 1, vz), Quaternion.identity);
            isEmpty = true;
            sr.sprite = sprite;
        }
    }
}
