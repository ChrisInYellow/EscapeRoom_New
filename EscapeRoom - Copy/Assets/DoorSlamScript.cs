using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlamScript : MonoBehaviour {

    public GameObject leftDoor;
    public GameObject rightDoor;

    private void OnTriggerEnter(Collider other)
    {
        leftDoor.GetComponent<Animator>().SetTrigger("DoorSlam");
        rightDoor.GetComponent<Animator>().SetTrigger("DoorSlam");
        Destroy(gameObject);
    }
}
