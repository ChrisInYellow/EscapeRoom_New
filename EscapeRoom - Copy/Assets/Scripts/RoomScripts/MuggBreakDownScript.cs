using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuggBreakDownScript : MonoBehaviour {

    public GameObject BrokenMugg;

    private void OnCollisionEnter(Collision collision)
    {
        if (Math.Abs(GetComponent<Rigidbody>().velocity.y) >= 0.3 || Math.Abs(GetComponent<Rigidbody>().velocity.x) >= 0.3 
            || Math.Abs(GetComponent<Rigidbody>().velocity.z) >= 0.3)
        {
            Instantiate(BrokenMugg, transform.position, Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("BreakingGlass");
        }   
    }
}