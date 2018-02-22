using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EyeScannerScript : MonoBehaviour {

    public UnityEvent completedEye = new UnityEvent();
    public GameObject interactableLens;
    public GameObject lamp;
    public bool CombinationSolved;

    private void Start()
    {
        lamp.GetComponent<MeshRenderer>().materials[0].color = new Color(1, 0, 0);
    }

    public void Unlock()
    {
        CombinationSolved = true;
        lamp.GetComponent<MeshRenderer>().materials[0].color = new Color(0, 1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CombinationSolved == true)
        {

            interactableLens.GetComponent<Animator>().SetTrigger("Zoom");
            FindObjectOfType<AudioManager>().Play("CameraZoom");
            if (other.tag == "EyeBall")
            {
                SolvePuzzle();
            }
            else
            {
                //FindObjectOfType<AudioManager>().Play("AccessDenied");
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        interactableLens.GetComponent<Animator>().SetTrigger("Unzoom");
        FindObjectOfType<AudioManager>().Play("CameraUnZoom");
    }

    public void SolvePuzzle()
    {
        completedEye.Invoke();
    }
}
