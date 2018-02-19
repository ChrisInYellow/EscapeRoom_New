﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {
    
    public bool batteryIsIn;
    public GameObject spotLight;

    public void Activate()
    {
        if (batteryIsIn)
        {
            spotLight.SetActive(true);
            FindObjectOfType<AudioManager>().Play("FlashlightClick");
        }
    }

    public void DeActivate()
    {
        spotLight.SetActive(false);
    }

    public void batteryInput()
    {
        FindObjectOfType<AudioManager>().Play("BatteryClick");
        batteryIsIn = true;
        Activate();
    }

    public void QuickSolve()
    {
        batteryIsIn = true;
        Activate();
    }
}
