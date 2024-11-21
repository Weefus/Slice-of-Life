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

    // Start is called before the first frame update
    void Start()
    {
        player = (Player)FindObjectOfType(typeof(Player));
        maxHP = hp;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            player.increaseScore(50);
        }
    }

}
