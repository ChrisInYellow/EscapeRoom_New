using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EyeScannerScript : MonoBehaviour {

    public UnityEvent completedEye = new UnityEvent();
    public GameObject interactableLens;
    public GameObject lamp;
    public bool CombinationSolved;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = lamp.GetComponent<MeshRenderer>();
        meshRenderer.material.SetColor("_EmissionColor", Color.red);
    }

    public void Unlock()
    {
        CombinationSolved = true;
        meshRenderer.material.SetColor("_EmissionColor", Color.green);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CombinationSolved == true)
        {
            interactableLens.GetComponent<Animator>().SetTrigger("Zoom");
            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().Play();
            if (other.tag == "EyeBall")
            {
                SolvePuzzle();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactableLens.GetComponent<Animator>().SetTrigger("Unzoom");
        if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
    }

    public void SolvePuzzle()
    {
        completedEye.Invoke();
    }
}
