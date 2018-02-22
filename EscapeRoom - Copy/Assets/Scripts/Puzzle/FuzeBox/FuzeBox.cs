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

    [HideInInspector]
    public bool fuzeIsSnapped = false;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Buzzing");
    }

    public void OnSnapped()
    {
        fuzeIsSnapped = true;
        fuzeInserted.Invoke();
        timeUntilRemoved = Random.Range(30, 60);
        Invoke("ShootOutFuze", timeUntilRemoved);
        FindObjectOfType<AudioManager>().Play("Laser");
    }

    public void ShootOutFuze ()
    {
        fuzeIsSnapped = false;
        fuzeRemoved.Invoke();
        Rigidbody rb = fuze.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce((-transform.right) * thrust);
        FindObjectOfType<AudioManager>().Pause("Laser");
        FindObjectOfType<AudioManager>().Play("PowerDown");
    }

    public void OnUnSnapped()
    {
        CancelInvoke();
        fuzeIsSnapped = false;
        fuzeRemoved.Invoke();
    }
}
