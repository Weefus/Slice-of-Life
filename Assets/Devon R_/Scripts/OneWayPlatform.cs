using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OneWayPlatform : MonoBehaviour
{
    public bool coll;

    public PlatformEffector2D platform;

    void Update()
    {
        if (coll && Input.GetKeyDown(KeyCode.S) && !CompareTag("Ground"))
        {
            platform.surfaceArc = 0f;

            StartCoroutine(Wait());
        }
    }

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

}