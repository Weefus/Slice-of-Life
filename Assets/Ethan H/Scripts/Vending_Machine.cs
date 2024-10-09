using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vending_Machine : MonoBehaviour
{
    public Pickup_collect pickup;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i = 0; i < 1; i++)
        {
            Instantiate(pickup);
        }
        
    }
}
