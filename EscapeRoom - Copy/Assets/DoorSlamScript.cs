using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSlamScript : MonoBehaviour {

    public UnityEvent DoorSlamed = new UnityEvent();
    public GameObject leftDoor;
    public GameObject rightDoor;
    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        DoorSlamActivate();
    }
    public void DoorSlamActivate()
    {
        player.position = new Vector3(player.position.x, player.position.y, 5.2f);
        leftDoor.GetComponent<Animator>().SetTrigger("DoorSlam"); ;
        rightDoor.GetComponent<Animator>().SetTrigger("DoorSlam");
        FindObjectOfType<AudioManager>().Play("DoorSlam");
        DoorSlamed.Invoke();
        Destroy(gameObject);
    }
}
