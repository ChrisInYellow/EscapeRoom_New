using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanAndEyeSound : MonoBehaviour {

    public void Eye()
    { 
        FindObjectOfType<AudioManager>().Play("EyeSquish");  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(transform.tag == "Can") {
            if (Math.Abs(GetComponent<Rigidbody>().velocity.y) >= 0.3 || Math.Abs(GetComponent<Rigidbody>().velocity.x) >= 0.3
                || Math.Abs(GetComponent<Rigidbody>().velocity.z) >= 0.3)
            {
                FindObjectOfType<AudioManager>().Play("CanDrop");
            }
        }
    }
}
