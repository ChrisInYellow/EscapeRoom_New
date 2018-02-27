using UnityEngine;
using UnityEngine.Events;

public class EyeScannerScript : MonoBehaviour {

    public UnityEvent completedEye = new UnityEvent();
    public GameObject interactableLens;
    public GameObject lamp;
    private bool CombinationSolved;
    private bool eyeShowed;
    public AudioClip zoom;
    public AudioClip unZoom;
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
        if (CombinationSolved)
        {
            interactableLens.GetComponent<Animator>().SetTrigger("Zoom");
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().clip = zoom;
                GetComponent<AudioSource>().Play();
            }
            if (other.tag == "EyeBall" && !eyeShowed)
            {
                eyeShowed = true;
                SolvePuzzle();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactableLens.GetComponent<Animator>().SetTrigger("Unzoom");
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().clip = unZoom;
            GetComponent<AudioSource>().Play();
        }

    }

    public void SolvePuzzle()
    {
        completedEye.Invoke();
    }
}
