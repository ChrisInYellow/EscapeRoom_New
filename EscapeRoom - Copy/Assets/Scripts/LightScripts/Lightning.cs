using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour 
{
    public float lightningStartTimer = 10f;
    public float lightningDuration = 0.05f;
    Light thisLight;
    LightShafts lightShaft;

    void Start () 
	{
        thisLight = GetComponent<Light>();
        lightShaft = GetComponent<LightShafts>();
        Invoke("Startlightning", lightningStartTimer);
    }
	
	void Update () 
	{
		
	}

    public void StartLightning ()
    {
        thisLight.enabled = true;
        lightShaft.enabled = true;
        Invoke("LightningOff", lightningDuration);
    }

    public void LightningOff ()
    {
        thisLight.enabled = false;
        lightShaft.enabled = false;
    }
}
