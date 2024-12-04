using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hologramCtrlr : MonoBehaviour
{
    private float time;
    public GameObject pickUp;
    public float endTime;
    private bool alive;

    // Start is called before the first frame update
    void Start()
    {
        alive = true; 
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time >= endTime) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hitbox") && alive)
        {
            Instantiate(pickUp, transform.position, pickUp.transform.rotation);
            alive = false;
            Destroy(gameObject);   
        }

    }
}
