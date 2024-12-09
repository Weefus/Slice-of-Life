using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    public ParticleSystem heal;
    public ParticleSystem dash;
    public ParticleSystem dashTwo;
    public ParticleSystem ultReady;
  
    public Dash dashScript;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        dashScript = GetComponent<Dash>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        var dashEmission = dash.emission;
        var dashTwoEmission = dashTwo.emission;

        if (dashScript.isDashing) //toggles emission for the dash particles
        {
            dashEmission.enabled = true;
            dashTwoEmission.enabled = true; 
        } else
        {
            dashEmission.enabled = false;
            dashTwoEmission.enabled = false;
        }

        var ultEmission = ultReady.emission;

        if (player.ult == 100)
        {
            ultEmission.enabled = true;
        } else
        {
            ultEmission.enabled = false;
        }
    }

    //plays the player healing effect
    public void PlayHealEffect()
    {
        if (heal.isPlaying)
            heal.Stop();

        if (heal.isStopped)
            heal.Play();
    }
}
