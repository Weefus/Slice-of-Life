using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class basicZombClass : MonoBehaviour
{

    public float hp;
    public Player player;
    public float atkStartUp;
    public float atkEnd;
    public float atkCd;
    public float maxHP;
    Animator animator;
    private float despawnTime = 5;

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
            animator.SetTrigger("die");

            despawnTime -= Time.deltaTime;

            if (gameObject.CompareTag("Miku"))
            {
                SceneManager.LoadScene("Win_Screen");
            }

            if (despawnTime <= 0)
            {
                Destroy(gameObject);
                player.increaseScore(50);
            }
        }
    }
}
