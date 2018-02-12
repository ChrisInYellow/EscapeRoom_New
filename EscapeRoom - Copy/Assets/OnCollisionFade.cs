using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OnCollisionFade : MonoBehaviour 
{
    public VRTK_HeadsetFade headSetFade;
    void Start () 
	{

	}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Niklas");
        Debug.Log(other.tag);
        if (other.tag == "Wall")
        {
            Debug.Log("WTF");
            headSetFade.Fade(new Color(0, 0, 0), 1f);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Wall")
        {
            headSetFade.Unfade(1f);
        }
    }
}
