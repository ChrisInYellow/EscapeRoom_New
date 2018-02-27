using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuzeBox : MonoBehaviour 
{

    public UnityEvent fuzeInserted = new UnityEvent();
    public UnityEvent fuzeRemoved = new UnityEvent();

    private float timeUntilRemoved;
    private float thrust = 50f;
    public GameObject fuze;
    
    public AudioClip laser;
    public AudioClip powerDown;

    Rigidbody rb;

    [HideInInspector]
    public bool fuzeIsSnapped = false;

    private void Start()
    {
        fuze.GetComponent<Rigidbody>();
    }

    public void OnSnapped()
    {
        fuzeIsSnapped = true;
        fuzeInserted.Invoke();
        timeUntilRemoved = Random.Range(30, 60);
        Invoke("ShootOutFuze", timeUntilRemoved);
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().clip = laser;
            GetComponent<AudioSource>().Play();
        }
    }

    public void ShootOutFuze ()
    {
        fuzeIsSnapped = false;
        fuzeRemoved.Invoke();
        rb.isKinematic = false;
        rb.AddForce((-transform.right) * thrust);
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().clip = powerDown;
            GetComponent<AudioSource>().Play();
        }
    }

    public void OnUnSnapped()
    {
        CancelInvoke();
        fuzeIsSnapped = false;
        fuzeRemoved.Invoke();
    }
}
