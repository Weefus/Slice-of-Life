using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicZombClass : MonoBehaviour
{

    public float hp;

    public float atkStartUp;
    public float atkEnd;
    public float atkCd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
