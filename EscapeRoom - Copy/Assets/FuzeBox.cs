using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuzeBox : MonoBehaviour 
{
    [SerializeField]
    public UnityEvent fuzeBoxRemoved = new UnityEvent();

    private float timeUntilRemoved;
    private float thrust;
    private GameObject privatefuze;

    public void OnSnapped(GameObject fuze)
    {
        timeUntilRemoved = Random.Range(30, 60);
        thrust = Random.Range(150, 200);
        privatefuze = fuze;
        Invoke("ShootOutFuze", timeUntilRemoved);
    }

    public void ShootOutFuze ()
    {
        fuzeBoxRemoved.Invoke();
        Rigidbody rb = privatefuze.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce((-transform.right) * thrust);
    }
}
