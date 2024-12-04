using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    Player player;
    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        player = (Player)FindObjectOfType(typeof(Player));
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.activeSelf == true)
        {
            Time.timeScale = 0.0f;
        }
        else if (player.isDead == false)
        {
            Time.timeScale = 1.0f;
            isPaused = false;
        }
    }

    public void pauseGame(InputAction.CallbackContext value)
    {
        Debug.Log("Game Paused");
        if (value.performed)
        {
            if (isPaused == false)
            {
                isPaused = true;
                pause.SetActive(true);
            }
            else
            {
                isPaused = false;
                pause.SetActive(false);
            }
        }
        
    }
}
