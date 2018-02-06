using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlashLight : MonoBehaviour {

    public bool isOn;
    public bool batteryIsIn;
    public bool lidIsOn = true;
    public GameObject spotLight;
    public DoorController doorManager; 

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
    }

    public void PutLidOn()
    {
        lidIsOn = true;

        if (batteryIsIn)
            Activate();
    }

    public void PutLidOff()
    {
        lidIsOn = false;
    }

    public void QuickSolve()
    {
        batteryIsIn = true;
        Activate();
    }
}
