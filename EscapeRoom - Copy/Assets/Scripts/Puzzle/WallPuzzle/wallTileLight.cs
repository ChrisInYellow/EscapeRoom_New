using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTileLight : MonoBehaviour 
{
    public GameObject fuzeBoxZone;
    Light light;

    void Start () 
	{
        light = GetComponent<Light>();
        fuzeBoxZone.GetComponent<FuzeBox>().lightOn += LightOn;
        fuzeBoxZone.GetComponent<FuzeBox>().lightOff += LightOff;
    }

    public void LightOn ()
    {
        light.intensity = 0;
    }

    public void LightOff ()
    {
        light.intensity = 0;
    }
}
