using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationLightFlicker : MonoBehaviour {

    public float timeToTurnOn = 0.05f;
    public GameObject thisLight;

    public void Start()
    {
        Invoke("LightOn", 0);
    }

    public void LightOff()
    {
        thisLight.SetActive(false);
        Invoke("LightOn", Random.Range(0, .5f));
    }

    void LightOn()
    {
        thisLight.SetActive(true);
        Invoke("LightOff", Random.Range(0, 1f));
    }
}
