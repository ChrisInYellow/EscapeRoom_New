using System;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public AudioClip batteryIn;
    public AudioClip click;

    public bool batteryIsIn;
    public GameObject spotLight;

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        if (batteryIsIn)
        {
            spotLight.SetActive(true);
            source.clip = click;
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
        source.clip = batteryIn;
        PlayClickSound();
    }

    void PlayClickSound()
    {
        if (source != null)
            source.Play();
    }
}
