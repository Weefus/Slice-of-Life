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
    public GameOver g;
    string currentScene;
    public float score = 20;
    public bool isDead = false;
    void Start()
    {
        uiSlider.updateHP();
        uiText.updateHP();
        g.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void die()
    {
        g.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        isDead = true;
        gameObject.SetActive(false);
    }

    public void increaseHP(float h)
    {
        hp += h;
        currentScene = SceneManager.GetActiveScene().name;
        if (hp > maxHP)
        {
            hp = maxHP;
        }
        uiSlider.updateHP();
        uiText.updateHP();
    }

    public void increaseScore(float s)
    {
        score += s;
        uiText.updateScore();
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
        SceneManager.LoadScene(currentScene);
        DontDestroyOnLoad(gameObject);
        Debug.Log("Whoops");
    }
}
