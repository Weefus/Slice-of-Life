using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicZombClass : MonoBehaviour
{
    public int hp;
    public float atkStartUp;
    public float atkEnd;
    public float atkCd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void takeDmg(int dmg) {
        hp = hp - dmg;
    }
}
