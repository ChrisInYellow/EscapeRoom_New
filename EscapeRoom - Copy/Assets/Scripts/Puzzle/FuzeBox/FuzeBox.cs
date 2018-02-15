using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuzeBox : MonoBehaviour 
{
    public System.Action lightOn;
    public System.Action lightOff;

    public bool isWallTileRelated = false;

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
        fuzeInserted.Invoke();
        timeUntilRemoved = Random.Range(30, 60);
        thrust = Random.Range(150, 200);
        Invoke("ShootOutFuze", timeUntilRemoved);
        if (isWallTileRelated)
        {
            lightOn();
        }
    }

    public void ShootOutFuze ()
    {
        fuzeIsSnapped = false;
        fuzeRemoved.Invoke();
        Rigidbody rb = fuze.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce((-transform.right) * thrust);
        if (isWallTileRelated)
        {
            lightOff();
        }
    }
}
