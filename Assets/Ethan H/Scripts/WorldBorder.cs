using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldBorder : MonoBehaviour
{
    public Player player;
    public float borderY = -20.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= borderY)
        {
            player.respawn();
        }
    }
}
