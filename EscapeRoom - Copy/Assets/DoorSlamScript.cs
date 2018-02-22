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
        player.position = new Vector3(player.position.x, player.position.y, 6.2f);
        leftDoor.GetComponent<Animator>().SetTrigger("DoorSlam"); ;
        rightDoor.GetComponent<Animator>().SetTrigger("DoorSlam");
        Invoke("PlaySound", .4f);
        DoorSlamed.Invoke();
    }
    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("DoorSlam");
        Destroy(gameObject);
    }
}
