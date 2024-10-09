using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float hp = 50;
    public float ult = 50;
    public float maxHP = 100;
    public float maxUlt = 100;
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void increaseHP(int h)
    {
        hp += h;
    }

    public void increaseUlt(int u)
    {
        ult += u;
    }

}
