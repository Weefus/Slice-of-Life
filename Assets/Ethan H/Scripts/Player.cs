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
    public int levelNum = 1;
    public UI_Update ui;
    void Start()
    {
        ui.updateHP();
        ui.updateUlt();
    }

    void Update()
    {
        
    }


    public void die()
    {
        Destroy(gameObject);
        Debug.Log("Womp womp");
    }

    public void increaseHP(float h)
    {
        hp += h;
        if (hp > maxHP)
        {
            hp = maxHP;
        }
        ui.updateHP();
    }

    public void increaseUlt(float u)
    {
        ult += u;
        if (ult > maxUlt) 
        {
            ult = maxUlt;
        }
        ui.updateUlt();
    }

    public void decreaseHP(float h)
    {
        hp -= h;
        if (hp <= 0)
        {
            hp = 0;
            die();
        }
        ui.updateHP();
    }

    public void respawn()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log("Whoops");
    }

}
