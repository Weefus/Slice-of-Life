using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float hp = 50;
    public float ult = 50;
    public float maxHP = 100;
    public float maxUlt = 100;
    public UI_Update uiSlider;
    public UI_Update uiText;
    public float spawnX = -2.2f;
    public float spawnY = -1.8f;
    public string dieScene;
    void Start()
    {
        uiSlider.updateHP();
        uiText.updateHP();
    }

    void Update()
    {
        
    }


    public void die()
    {
        SceneManager.LoadScene(dieScene);
        Debug.Log("Womp womp");
    }

    public void increaseHP(float h)
    {
        hp += h;
        if (hp > maxHP)
        {
            hp = maxHP;
        }
        uiSlider.updateHP();
        uiText.updateHP();
    }

    /*public void increaseUlt(float u)
    {
        ult += u;
        if (ult > maxUlt) 
        {
            ult = maxUlt;
        }
        ui.updateUlt();
    }*/

    public void decreaseHP(float h)
    {
        hp -= h;
        if (hp <= 0)
        {
            hp = 0;
            die();
        }
        uiSlider.updateHP();
        uiText.updateHP();
    }

    public void respawn()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log("Whoops");
    }
}
