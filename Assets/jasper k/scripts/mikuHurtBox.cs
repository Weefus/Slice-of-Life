using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mikuHurtBox : MonoBehaviour
{
    public miku_class mikuClass;
    
    void Start()
    {
        mikuClass = GetComponent<miku_class>();
    }

    public void DealDamage(float damageAmt) //deals damage to miku
    {
        if (mikuClass != null)
        {
            mikuClass.takeDmg(damageAmt);
        }
    }
}
