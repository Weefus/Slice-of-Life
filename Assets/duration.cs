using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duration : MonoBehaviour
{
    public float endtime;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > endtime) {
            Destroy(gameObject);
        }
    }
}
