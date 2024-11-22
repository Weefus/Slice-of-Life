using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using TMPro.Examples;
using UnityEngine.UI;

public class UI_Update : MonoBehaviour
{
    public TMP_Text hpText;
    public TMP_Text ultText;
    public TMP_Text scoreText;
    public Player player;
    public Slider hpBar;
    void Start()
    {
        player = (Player)FindObjectOfType(typeof(Player));
        Debug.Log(player.name);
        updateHP();
        updateUlt();
        updateScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateHP()
    {
        hpBar.maxValue = player.maxHP;
        hpBar.value = player.hp;
        hpText.text = "HP: " + (player.hp);
    }

    public void updateScore()
    {
        
        scoreText.text = "Score: \n" + player.score;
    }

   public void updateUlt()
    {
        ultText.text = (player.ult) + "%";
    }
}
