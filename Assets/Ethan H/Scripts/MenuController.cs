using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public InputAction esc;
    public bool isOpen = true;
    public GameObject mainScreen;
    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        //esc = InputSystem.actions.FindAction("Close Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openMenu(InputAction.CallbackContext value)
    {
        Debug.Log("Hello chat");
        if (isOpen == false)
        {
            mainScreen.SetActive(true);
            isOpen = true;
        }
        else
        {
            mainScreen.SetActive(false);
            isOpen = false;
        }
    }

    void closeMenu()
    {

    }
}
