using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlashLight : MonoBehaviour {

    [SerializeField]
    public UnityEvent puzzleSolved = new UnityEvent();

    public bool isOn;
    public bool batteryIsIn;
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
        Activate();
        puzzleSolved.Invoke();
    }
}
