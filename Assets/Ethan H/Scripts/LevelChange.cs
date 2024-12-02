using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using TMPro.Examples;

public class LevelChange : MonoBehaviour
{
    public string sceneName;
    public Player p;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided");
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
            DontDestroyOnLoad(p);
            Debug.Log("Scene switched");
            p.transform.position = new Vector3(p.spawnX, p.spawnY, 0);

        }
    }
}
