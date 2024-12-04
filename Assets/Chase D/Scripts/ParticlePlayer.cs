using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    public ParticleSystem heal;
    public ParticleSystem dash;
    public Dash dashScript;

    // Start is called before the first frame update
    void Start()
    {
        
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
