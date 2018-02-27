using System;
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
        StartCoroutine(PlaySound());
        DoorSlamed.Invoke();
    }
    
    private IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(.4f);
        if(GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(.8f);
        Destroy(gameObject);
    }
}
