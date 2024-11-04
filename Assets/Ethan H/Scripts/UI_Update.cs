using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using TMPro.Examples;

public class UI_Update : MonoBehaviour
{
    public TMP_Text uiText;
    public TMP_Text ultText;
    public Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateHP()
    {
        uiText.text = "HP: " + (player.hp);
    }

    public void updateUlt()
    {
        ultText.text = "ULT: " + (player.ult);
    }
}
