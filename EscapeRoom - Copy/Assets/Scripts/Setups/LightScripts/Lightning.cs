using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour 
{
    public float lightningStartTimer = 10f;
    public float lightningDuration = 0.05f;

    public GameObject lightning01;
    public GameObject lightning02;

    void Start () 
	{
        Invoke("StartLightning", lightningStartTimer);
    }

    public void StartLightning ()
    {
        lightning01.SetActive(true);
        lightning02.SetActive(true);

        Invoke("LightningOff", lightningDuration);
    }

    public void LightningOff ()
    {
        lightning01.SetActive(false);
        lightning02.SetActive(false);

        Invoke("StartLightning", Random.Range(5, 10));
    }
}
