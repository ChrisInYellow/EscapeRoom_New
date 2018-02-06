using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlashLight : MonoBehaviour {

    public bool isOn;
    public bool batteryIsIn;
    public bool LidIsOn = true;
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

    public void lidOn()
    {
        LidIsOn = true;
        if (batteryIsIn)
            Activate();
    }

    public void lidOff()
    {
        LidIsOn = false;
    }

    public void QuickSolve()
    {
        LidIsOn = true;
        batteryIsIn = true;
        spotLight.SetActive(true);
    }
}
