using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapRopeTest : MonoBehaviour {

    public GameObject ropeBurningLaser;
    public GameObject rope;
    public GameObject snappedRope;
    public GameObject smoke;
    public GameObject fire;

	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject) //Check what other object has collided
        //{
        //    RopeHit();
        //}
    }

    public void RopeHit()
    {
        Invoke("TimeUntilSmoke", 0.5f);
    }

    void Smoke()
    {
        //do smoke stuff
        Invoke("TimeUntilFire", 3);
    }

    void Fire()
    {
        //Do fire stuff
        Invoke("TimeUntilBreak", 2);
    }

    void Break()
    {
        //swap model
        //turn of effects
    }

    public void RopeMissed()
    {
        //laser moved away
        CancelInvoke();
        //turn off all effects
    }
}
