using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static Hitbox;

public class Hitbox : MonoBehaviour
{
    [SerializeField] public ColliderState _state;
    public Hurtbox ignore;
    public float damageAmt = 3;
    public float knockbackForce = 5;
    public Vector3 direction;

    //states for the hitbox
    public enum ColliderState
    {
        Open,

        Closed
    }
    void Start()
    {
        ignore = GetComponentInParent<Hurtbox>(); //Sets the hurtbox of the hitbox parent to ignore triggers
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_state == ColliderState.Closed) //return if hitbox is inactive
        {
            return;
        }

        Hurtbox h = col.GetComponent<Hurtbox>();
        KnockbackController kb = col.GetComponent<KnockbackController>();

        if (h != null && h != ignore) //only triggers is a hurtbox exists and does not share the same parent
        {
            direction = (h.transform.position - transform.position).normalized; //sets direction for the knockback based on the positions of the hitbox and colliding hurtbox
            direction.y += 1f;

            h.DealDamage(damageAmt);
            kb.Knockback(direction * knockbackForce);
        }
    }
}
