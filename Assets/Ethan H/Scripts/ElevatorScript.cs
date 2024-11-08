using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public GameObject elev;
    bool isAscending = false;
    float yEnd = 100;
    float speed = 3;
    public GameObject door1;
    public GameObject door2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isAscending == true)
        {
            elev.transform.Translate(0, Time.deltaTime * speed, 0);
            if (elev.transform.position.y >= yEnd)
            {
                isAscending = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isAscending == false)
            {
                door1.transform.position = new Vector3(door1.transform.position.x, 2f, 0);
                door2.transform.position = new Vector3(door2.transform.position.x, 2f, 0);
            }
            isAscending = true;
            Debug.Log("Hi squidward");
        }
    }
}
