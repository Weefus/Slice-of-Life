using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OneWayPlatform : MonoBehaviour
{
    //If there is a collision on the platform
    public bool coll;

    public PlatformEffector2D platform;

    //if yes collision true
    private void OnCollisionEnter2D(Collision2D collision)
    {
        coll = true;
    }

    //if no more collision false
    private void OnCollisionExit2D(Collision2D collision)

    {
        coll = false;
    }

    //Waits to return platform to original state
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);

        //original platform collision arc
        platform.surfaceArc = 180f;
    }

    //Input for when the player presses down
    public void Fall(InputAction.CallbackContext value)
    {
        //Starts the input
        if (value.started && coll && !CompareTag("Ground"))
        {
            //makes the platform intangable
            platform.surfaceArc = 0f;

            //cooldown for the tangability
            StartCoroutine(Wait());
        }
        //Input was canceled
        else if (value.canceled)
        {

        }
    }

}