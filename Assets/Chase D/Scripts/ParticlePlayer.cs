using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    public ParticleSystem heal;
    public ParticleSystem dash;
    public ParticleSystem ultReady;
    public ParticleSystem ultReady2;
    public ParticleSystem ultReady3;

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
        

        if (dashScript.isDashing) //toggles emission for the dash particles
        {
            dashEmission.enabled = true;
           
        } else
        {
            dashEmission.enabled = false;
        
        }

       var ultEmission = ultReady.emission;
       var ultEmission2 = ultReady2.emission;
       var ultEmission3 = ultReady3.emission;

        if (player.ult == 100)
        {
            ultEmission.enabled = true;
            ultEmission2.enabled = true;
            ultEmission3.enabled = true;
        } else
        {
            ultEmission.enabled = false;
            ultEmission2.enabled = false;
            ultEmission3.enabled = false;
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
