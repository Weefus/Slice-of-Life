using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    //if the player can dash
    public bool canDash = true;
    //if the player is in the middle of a dash
    public bool isDashing;
    //the multiplier behind a dash
    public float dashingPower = 24f;
    //time it takes to complete a dash
    public float dashingTime = 0.5f;
    //Time after dash where you can't dash
    public float dashingCooldown = 2f;
    //Player rigidbody
    private Rigidbody2D myRB;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    //Dash action
    public IEnumerator dashDuration(float direction)
    {
        //can no longer dash for a bit
        canDash = false;
        //Locks movement while dashing
        isDashing = true;

        //saves gravity
        float originalGravity = myRB.gravityScale;
        //sets player to weightless
        myRB.gravityScale = 0f;
        //sets velocity to zero (so that dash isn't affected by initial velocity)
        myRB.velocity = new Vector2(0f, 0f);
        //Pushes the player the distance of the dash in the direction given
        myRB.AddForce(new Vector2(dashingPower * direction, 0f), ForceMode2D.Impulse);
        //allows for all of force to continue for all dash
        Debug.Log("Started dash");
        yield return new WaitForSeconds(dashingTime);

        //sets the gravity back to what it was
        Debug.Log("Ended dash");
        myRB.gravityScale = originalGravity;
        //lets the player regain control
        isDashing = false;

        //waits till you can dash again
        yield return new WaitForSeconds(dashingCooldown);
        Debug.Log("off cooldown");

        //player can dash again
        canDash = true;
    }
}
