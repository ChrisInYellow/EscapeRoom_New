using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
using VRTK;

public class CreditsFade : MonoBehaviour
{
    //public UnityEvent CreditTriggered; 
    public VRTK_HeadsetFade fade;
    public Camera creditsCam;
    public float dur;


    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        fade.Fade(new Color(0, 0, 0), dur);

        StartCoroutine(CreditSpwan()); 
        //print("Mah balls");


        //Invoke("CreditSpawn", dur);
    }
    private IEnumerator CreditSpwan()

    {
        yield return new WaitForSeconds(dur);
        fade.Unfade(dur); 
        creditsCam.transform.gameObject.SetActive(true);
    }

}
