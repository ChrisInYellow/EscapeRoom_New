using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpEffect : MonoBehaviour {

    public float timeLeft;
    public Camera wakeUpCam;
    
	void Awake () {
        wakeUpCam.enabled = false;
	}
	
	void Update () {
        Countdown();
        EnableCam();
	}

    void Countdown()
    {
        timeLeft -= Time.deltaTime;
    }

    void EnableCam()
    {
        if(wakeUpCam.enabled == false && timeLeft < 0)
        {
            wakeUpCam.enabled = true;
        }
    }
}
