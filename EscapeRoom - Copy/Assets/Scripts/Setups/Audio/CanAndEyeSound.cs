using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanAndEyeSound : MonoBehaviour
{
    AudioSource source;
    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Eye()
    {
        source.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(transform.tag == "Can")
        {
            if (Math.Abs(GetComponent<Rigidbody>().velocity.y) >= 0.3 || Math.Abs(GetComponent<Rigidbody>().velocity.x) >= 0.3
                || Math.Abs(GetComponent<Rigidbody>().velocity.z) >= 0.3)
            {
                source.Play();
            }
        }
    }
}
