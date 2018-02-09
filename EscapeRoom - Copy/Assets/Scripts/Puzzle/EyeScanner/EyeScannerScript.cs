using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EyeScannerScript : MonoBehaviour {

    public UnityEvent completedEye = new UnityEvent();


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EyeBall")
        {
            SolvePuzzle();
        }
    }

    public void SolvePuzzle()
    {
        completedEye.Invoke();
    }
}
