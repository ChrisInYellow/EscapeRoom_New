using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimator : MonoBehaviour {

    private LineRenderer laser;
    public int numberOfFrames;
    private float startingWitdth;
    private float endingWidth;
    private bool increment;
    public float inc_value; 


	// Use this for initialization
	void Start () {
        laser = gameObject.GetComponent<LineRenderer>();
        startingWitdth = laser.startWidth;
        endingWidth = laser.endWidth; 
	}
	
	// Update is called once per frame
	void Update () {
        if (laser.endWidth <= 0.02)
        {
            increment = true; 
        }
        else if(laser.endWidth >= 0.05)
        {
            increment = false; 
        }
        if(increment)
        {
            laser.endWidth = laser.startWidth += inc_value; 
        }
        else
        {
            laser.endWidth = laser.startWidth -= inc_value; 
        }
	}
}
