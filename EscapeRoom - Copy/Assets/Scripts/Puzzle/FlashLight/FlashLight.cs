using System;
using UnityEngine;

public class FlashLight : MonoBehaviour {
    
    public bool batteryIsIn;
    public GameObject spotLight;

    public void Activate()
    {
        if (batteryIsIn)
        {
            spotLight.SetActive(true);
            PlayClickSound();
        }
    }

    public void DeActivate()
    {
        spotLight.SetActive(false);
        PlayClickSound();
    }

    public void batteryInput()
    {
        batteryIsIn = true;
        spotLight.SetActive(true);
        PlayClickSound();
    }

    void PlayClickSound()
    {
        if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
    }
}
