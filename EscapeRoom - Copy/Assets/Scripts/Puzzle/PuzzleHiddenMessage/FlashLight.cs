using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    public bool isOn;
    public bool batteryIsIn;
    public GameObject spotLight;

    public void Activate()
    {
        if (isOn)
            DeActivate();
        if (batteryIsIn)
        {
            isOn = true;
            spotLight.SetActive(true);
            FindObjectOfType<AudioManager>().Play("FlashlightClick");
        }
    }

    public void DeActivate()
    {
        isOn = false;
        spotLight.SetActive(false);
    }

    public void batteryInput()
    {
        FindObjectOfType<AudioManager>().Play("BatteryClick");

        batteryIsIn = true;
    }

    public void QuickSolve()
    {
        batteryIsIn = true;
        Activate();
    }
}
