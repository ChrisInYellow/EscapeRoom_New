using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlashLight : MonoBehaviour {

    public bool isOn;
    public bool batteryIsIn;
    public GameObject spotLight;

    public void Activate()
    {
        if (batteryIsIn)
        {
            spotLight.SetActive(true);
            FindObjectOfType<AudioManager>().Play("BatteryClick");
        }
    }

    public void DeActivate()
    {
        spotLight.SetActive(false);
    }

    public void batteryInput()
    {
        batteryIsIn = true;
        Activate();
    }

    public void QuickSolve()
    {
        batteryIsIn = true;
        Activate();
    }
}
