using UnityEngine;
using UnityEngine.Events; 
using VRTK;

public class OnCollisionFade : MonoBehaviour 
{
    public UnityEvent FadeTrigger = new UnityEvent(); 
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
