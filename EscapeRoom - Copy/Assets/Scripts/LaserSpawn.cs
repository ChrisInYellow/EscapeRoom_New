using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour {

    //public LineRenderer laser;
    public Vector3 amountOfDegrees; 
    public float speed; 
    private Quaternion laserRotation; 
    

	// Use this for initialization
	void Start () {

         gameObject.transform.Rotate(Vector3.zero); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RealignLaser()
    {
        gameObject.transform.Rotate(amountOfDegrees); 
    }
}
