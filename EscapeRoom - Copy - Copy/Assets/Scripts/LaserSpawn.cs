using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour {

    public LineRenderer laser;
    private Quaternion laserRotation; 
    

	// Use this for initialization
	void Start () {

        laserRotation = gameObject.transform.rotation; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RealignLaser()
    {
        laserRotatio
    }
}
