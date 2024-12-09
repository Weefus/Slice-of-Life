using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OneWayPlatform : MonoBehaviour
{
    //If there is a collision on the platform
    public GameObject coll;

    public PlatformEffector2D platform;

    //if yes collision true
    private void OnCollisionEnter2D(Collision2D collision)
    {
        coll = collision.gameObject;
    }

    //if no more collision false
    private void OnCollisionExit2D(Collision2D collision)

    {
        coll = null;
    }

    //Waits to return platform to original state
    IEnumerator Wait()
    {
        BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
        if (coll != null)
        {
            BoxCollider2D playerCollider = coll.GetComponent<BoxCollider2D>();

            Physics2D.IgnoreCollision(playerCollider, boxCollider);
            yield return new WaitForSeconds(1f);
            Physics2D.IgnoreCollision(playerCollider, boxCollider, false);
        }
    }

    //Input for when the player presses down
    public void Fall(InputAction.CallbackContext value)
    {
        //Starts the input
        if (value.started && !CompareTag("Ground")) 
        { 
            //cooldown for the tangability
            StartCoroutine(Wait());
        }
        //Input was canceled
        else if (value.canceled)
        {

        }
    }

}