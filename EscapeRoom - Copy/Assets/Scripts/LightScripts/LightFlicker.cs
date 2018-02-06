using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour 
{
    public float timeToTurnOn = 0.05f;
    public bool hasLightShaft = true;
    private int frames = 0;
    Light thisLight;
    LightShafts lightShaft;

    public void Start()
    {
        thisLight = GetComponent<Light>();
        lightShaft = GetComponent<LightShafts>();
        Invoke("LightOn", 0);
    }

    public void LightOff ()
    {
        if (hasLightShaft)
        {
            lightShaft.enabled = false;
        }
        thisLight.enabled = false;
        Invoke("LightOn", Random.Range(0, .5f));
    }

    void LightOn()
    {
        if (hasLightShaft)
        {
            lightShaft.enabled = true;
        }
        thisLight.enabled = true;
        Invoke("LightOff", Random.Range(0, 1f));
    }
    //edit in runtime/copy multiple components?
}
