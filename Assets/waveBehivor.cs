using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveBehivor : MonoBehaviour
{
    public float speed;
    public float yDirection;
    public float time;
    public float returnTime;
    public float target;
    private float destroyPoint;

    // Start is called before the first frame update
    void Start()
    {
        yDirection = 1;
        time = 0;
        destroyPoint = transform.position.y - .1f;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > returnTime) {
            yDirection = -1;
        }

        if (transform.position.y <= target) { 
        transform.Translate(transform.up * speed * Time.deltaTime * yDirection);
        }

        if (transform.position.y <= destroyPoint) {
            Destroy(gameObject);
        }
    }

    
}
