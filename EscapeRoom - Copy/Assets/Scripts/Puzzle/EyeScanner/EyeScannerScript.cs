using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EyeScannerScript : MonoBehaviour {

    public UnityEvent completedEye = new UnityEvent();
    public GameObject interactableLens;
    public GameObject lamp;
    public bool CombinationSolved;

    public void Unlock()
    {
        CombinationSolved = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CombinationSolved == true)
        {
            lamp.GetComponent<Material>().color = new Color(0, 1, 0);

            if (other.tag == "EyeBall")
            {
                SolvePuzzle();
            }

            interactableLens.GetComponent<Animator>().SetTrigger("Zoom");

            if (other.tag == "MainCamera")
            {
                FindObjectOfType<AudioManager>().Play("AccessDenied");
            }
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
