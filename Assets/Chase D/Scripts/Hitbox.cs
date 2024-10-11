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

    public enum ColliderState
    {
        Open,

        Closed
    }
    void Start()
    {
        ignore = GetComponentInParent<Hurtbox>();

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_state == ColliderState.Closed)
        {
            return;
        }

        Hurtbox h = col.GetComponent<Hurtbox>();

        if (h != null && h != ignore)
        {
            direction = (h.transform.position - transform.position).normalized;
            direction.y += 1f;
            h.DealDamage(damageAmt);
            h.Knockback(direction * knockbackForce);
        }

        Debug.Log("collide");
    }
}
