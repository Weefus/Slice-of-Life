using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomProjectileAttack : MonoBehaviour
{
    private bool canHit;
    private bool isAtking;
    public bool canMove;
    public float time;
    public LayerMask mask;
    public float startTS;
    public float endTS;
    public float durationS;
    public Collider2D coll;
    public float dmg;
    public Vector3 direction;
    public int force;
    public float range;
    public float cooldown;
    public float fixedCooldown;
    public GameObject zomProj;

    // Start is called before the first frame update
    void Start()
    {
        isAtking = false;
        canMove = true;
        canHit = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        cooldown -= Time.deltaTime;

        if (time >= durationS)
        {
            isAtking = false;
            canMove = true;
            canHit = true;
            transform.parent.GetComponent<zombieMove>().canMove = true;
        }

        if (cooldown < 0)
        {
            canMove = false;
            Instantiate(zomProj);
            
           cooldown = fixedCooldown;
            canMove = true;
        }

  
    }

    
}
