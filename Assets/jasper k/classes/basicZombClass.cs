using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicZombClass : MonoBehaviour
{

    public float hp;
    public Player player;
    public float atkStartUp;
    public float atkEnd;
    public float atkCd;
    public float maxHP;
<<<<<<< Updated upstream
    Animator animator;
    private float despawnTime = 5;
=======
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = (Player)FindObjectOfType(typeof(Player));
        maxHP = hp;
    }

    private void Update()
    {
        if (hp <= 0)
        {
<<<<<<< Updated upstream
            animator.SetTrigger("die");

            despawnTime -= Time.deltaTime;

            if (despawnTime <= 0)
            {
                Destroy(gameObject);
                player.increaseScore(50);
            }
=======
            Destroy(gameObject);
            player.increaseScore(50);
>>>>>>> Stashed changes
        }
    }
}
