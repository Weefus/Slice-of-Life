using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkControler : MonoBehaviour
{
    public int actionCount;

    // Start is called before the first frame update
    void Start()
    {
        actionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void act() { 
        actionCount++;
    }

    public void reset()
    {
        actionCount = 0;
    }
}
