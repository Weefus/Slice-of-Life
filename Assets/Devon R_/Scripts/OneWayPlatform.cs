using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OneWayPlatform : MonoBehaviour
{
    public bool coll;

    public PlatformEffector2D platform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        coll = true;
    }

    private void OnCollisionExit2D(Collision2D collision)

    {
        coll = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);

        platform.surfaceArc = 180f;
    }

    public void Fall(InputAction.CallbackContext value)
    {
        if (value.started && coll && !CompareTag("Ground"))
        {
            platform.surfaceArc = 0f;

            StartCoroutine(Wait());
        }
        else if (value.canceled)
        {

        }
    }

}