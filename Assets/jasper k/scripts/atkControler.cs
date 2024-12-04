using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkControler : MonoBehaviour
{
    public int actionCount = 0;
    public int actionsAfterHolo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void act() { 
        actionCount++;
        
    }

    public void actHolo()
    {
        
        actionsAfterHolo++;
    }

    public void reset()
    {
        actionCount = 0;
    }
    public void resetHoloCount()
    {
        actionsAfterHolo = 0;
    }
}
