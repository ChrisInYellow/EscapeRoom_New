using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator anim; 
    public bool unlocked;
    public Material other_mat;
    public GameObject secretWall;
 
    public void Unlock()
    {
        unlocked = true;
    }

    public void OpenDoor()
    {
    
        if (unlocked == true)
        {
            secretWall.SetActive(false);
            GetComponent<MeshRenderer>().material = other_mat;
            anim.SetTrigger("DoorOpens");
            FindObjectOfType<AudioManager>().Play("DoorCreak");
        }
    }
}
