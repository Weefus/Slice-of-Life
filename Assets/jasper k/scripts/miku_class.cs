using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miku_class : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
      

    public void takeDmg(float damage) {

        hp = hp - damage;

    }
}
