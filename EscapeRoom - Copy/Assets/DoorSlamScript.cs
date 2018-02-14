using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSlamScript : MonoBehaviour {

    public UnityEvent DoorSlamed = new UnityEvent();
    public bool doorslamed;
    public GameObject leftDoor;
    public GameObject rightDoor;

    private void OnTriggerEnter(Collider other)
    {
        DoorSlamActivate();
    }
    public void DoorSlamActivate()
    {
        leftDoor.GetComponent<Animator>().SetTrigger("DoorSlam");
        rightDoor.GetComponent<Animator>().SetTrigger("DoorSlam");
        DoorSlamed.Invoke();
        Destroy(gameObject);
    }
}
