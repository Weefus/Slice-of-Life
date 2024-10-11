using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.5f;
    private float dashingCooldown = 2f;
    private Rigidbody2D myRB;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    public IEnumerator dashDuration(float direction)
    {
        canDash = false;
        isDashing = true;

        float originalGravity = myRB.gravityScale;
        myRB.gravityScale = 0f;
        myRB.velocity = new Vector2(myRB.velocity.x, 0f);
        myRB.AddForce(new Vector2(dashingPower * direction, 0f), ForceMode2D.Impulse);

        Debug.Log("Started dash");
        yield return new WaitForSeconds(dashingTime);

        Debug.Log("Ended dash");
        myRB.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashingCooldown);
        Debug.Log("off cooldown");

        canDash = true;
    }
}
