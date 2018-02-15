using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuzeBox : MonoBehaviour 
{
    public System.Action lightOn;
    public System.Action lightOff;

    public UnityEvent fuzeInserted = new UnityEvent();
    public UnityEvent fuzeRemoved = new UnityEvent();

    private float timeUntilRemoved;
    private float thrust;
    public GameObject fuze;

    [HideInInspector]
    public bool fuzeIsSnapped = false;

    public void OnSnapped()
    {
        fuzeIsSnapped = true;
        //lightOn();
        fuzeInserted.Invoke();
        timeUntilRemoved = Random.Range(30, 60);
        thrust = Random.Range(150, 200);
        Invoke("ShootOutFuze", timeUntilRemoved);
    }

    public void ShootOutFuze ()
    {
        fuzeIsSnapped = false;
        //lightOff();
        fuzeRemoved.Invoke();
        Rigidbody rb = fuze.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce((-transform.right) * thrust);
    }
}
