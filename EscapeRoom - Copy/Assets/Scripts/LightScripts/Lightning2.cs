using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning2 : MonoBehaviour
{
    public float lightningStartTimer = 10f;
    public float lightningDuration = 0.05f;
    private int numberOfFlickers = 0;
    Light thisLight;
    Animator anim;

    void Start()
    {
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
        Debug.Log(numberOfFlickers);
        Invoke("LightningSound", Random.Range(.3f, .5f));
        Invoke("LightningOff", lightningDuration);
    }

    public void LightningSound ()
    {
        FindObjectOfType<AudioManager>().Play("Thunder");
    }

    public void Lightning()
    {
        thisLight.enabled = true;
        anim.SetTrigger("Lightning");
    }

    public void LightningOff()
    {
        thisLight.enabled = false;
        Invoke("StartLightning", Random.Range(7, 20));
    }
}
