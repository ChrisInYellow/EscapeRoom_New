using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    public UnityEvent puzzleSolved = new UnityEvent();
    public Animator anim; 
    public bool left;

    public void OpenDoor()
    {
        if (left)
        {
            anim.SetTrigger("DoorOpens");
            FindObjectOfType<AudioManager>().Play("DoorCreak");
            puzzleSolved.Invoke();
        }
        else
        {
            anim.SetTrigger("DoorOpens");
        }
    }
}
