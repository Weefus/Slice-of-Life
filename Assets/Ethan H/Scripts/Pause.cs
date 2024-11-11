using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseGame(InputAction.CallbackContext value)
    {
        Debug.Log("Game Paused");
        if (value.performed)
        {
            if (isPaused == false)
            {
                Time.timeScale = 0.0f;
                isPaused = true;
                pause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                isPaused = false;
                pause.SetActive(false);
            }
        }
        
    }
}
