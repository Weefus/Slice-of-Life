using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public GameObject elev;
    bool isAscending = false;
    public float yEnd;
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
            if (isAscending == false && elev.transform.position.y >= yEnd)
            {
                door1.transform.position = new Vector3(door1.transform.position.x, -2f, door1.transform.position.z);
                door2.transform.position = new Vector3(door2.transform.position.x, -2f, door1.transform.position.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isAscending == false)
            {
                isAscending = true;
                door1.transform.position = new Vector3(door1.transform.position.x, 2f, door1.transform.position.z);
                door2.transform.position = new Vector3(door2.transform.position.x, 2f, door1.transform.position.z);
            }
        }
    }
}
