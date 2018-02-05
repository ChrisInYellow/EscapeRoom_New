using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour 
{
    public float timeToTurnOn = 0.1f;
    private int frames = 0;
    Light light;

    public void Start()
    {
        light = GetComponent<Light>();
    }

    void Update () 
	{
        frames++;
        if (frames % (Random.Range(75, 100)) == 0)
        {
            LightOf();
        }
	}

    public void LightOf ()
    {
        for (int i = 0; i < 3; i++)
        {
            light.enabled = false;
            //gameObject.SetActive(false);
            StartCoroutine(LightOn());
        }
    }

    IEnumerator LightOn ()
    {
        yield return new WaitForSeconds(timeToTurnOn);
        light.enabled = true;
        //gameObject.SetActive(true);
        //frames = 0;
    }
}
