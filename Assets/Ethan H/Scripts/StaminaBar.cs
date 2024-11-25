using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = (Player)FindObjectOfType(typeof(Player));
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = player.stamina;
    }
}
