using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OnCollisionFade : MonoBehaviour 
{
    public VRTK_HeadsetFade headSetFade;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            headSetFade.Fade(new Color(0, 0, 0), .5f);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            headSetFade.Unfade(.5f);
        }
    }
}
