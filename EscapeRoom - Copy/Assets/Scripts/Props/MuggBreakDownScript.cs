using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuggBreakDownScript : MonoBehaviour {

    public GameObject BrokenMugg;
    public float breakSpeed = 0.3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (Math.Abs(GetComponent<Rigidbody>().velocity.y) >= breakSpeed || Math.Abs(GetComponent<Rigidbody>().velocity.x) >= breakSpeed 
            || Math.Abs(GetComponent<Rigidbody>().velocity.z) >= breakSpeed)
        {
            Instantiate(BrokenMugg, transform.position, transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("BreakingGlass");
        }   
    }
}