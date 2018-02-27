using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning2 : MonoBehaviour
{
    public AudioClip thunder01;
    public AudioClip thunder02;
    public AudioClip thunder03;

    public float lightningStartTimer = 10f;
    public float lightningDuration = 0.05f;
    private int numberOfFlickers = 0;
    Light thisLight;
    Animator anim;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        thisLight = GetComponent<Light>();
        anim = GetComponent<Animator>();
        Invoke("StartLightning", lightningStartTimer);
    }

    public void StartLightning()
    {
        numberOfFlickers = Random.Range(1, 3);
        for (int i = 0; i < numberOfFlickers; i++)
        {
            Invoke("Lightning", i * .6f);
        }
        Invoke("LightningSound", Random.Range(.3f, .5f));
        Invoke("LightningOff", lightningDuration);
    }

    public void LightningSound ()
    {
        int randomThunder = Random.Range(1, 3);

        if (randomThunder == 1)
        {
            source.clip = thunder01;
        }
        if (randomThunder == 2)
        {
            source.clip = thunder02;
        }
        if (randomThunder == 3)
        {
            source.clip = thunder03;
        }
        source.Play();
    }

    public void Lightning()
    {
        thisLight.enabled = true;
        anim.SetTrigger("Lightning");
    }

    public void LightningOff()
    {
        thisLight.enabled = false;
        Invoke("StartLightning", Random.Range(30, 70));
    }
}
