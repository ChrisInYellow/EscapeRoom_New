using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EyeScannerScript : MonoBehaviour {

    public UnityEvent completedEye = new UnityEvent();
    public GameObject interactableLens;


    private void OnTriggerEnter(Collider other)
    {
        interactableLens.GetComponent<Animator>().SetTrigger("Zoom");
        if (other.tag == "EyeBall")
        {
            SolvePuzzle();
        }

        if(other.tag == "MainCamera")
        {
            FindObjectOfType<AudioManager>().Play("AccessDenied");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactableLens.GetComponent<Animator>().SetTrigger("Unzoom");
    }

    public void SolvePuzzle()
    {
        completedEye.Invoke();
    }
}
