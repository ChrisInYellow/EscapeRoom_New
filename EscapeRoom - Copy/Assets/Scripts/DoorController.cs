using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator anim; 
    public bool unlocked;
 
    public void Unlock()
    {
        unlocked = true;
    }

    public void OpenDoor()
    {
    
        if (unlocked == true)
        {
            anim.SetTrigger("DoorOpens");
            FindObjectOfType<AudioManager>().Play("DoorCreak");
        }
    }
}
