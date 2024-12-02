using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using TMPro.Examples;
using UnityEngine.UI;

public class MikuHealth : MonoBehaviour
{
    public basicZombClass miku;
    public Slider healthBar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = miku.hp;
    }

}
