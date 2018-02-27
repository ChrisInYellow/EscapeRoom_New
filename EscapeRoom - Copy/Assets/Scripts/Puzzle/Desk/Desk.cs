using System;
using UnityEngine;

public class Desk : MonoBehaviour {

    private Animator anim;
    public GameObject drawerItem;

    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    public void Open()
    {
        anim.SetBool("Open", true);
        Invoke("ActivateItem",0.5f);
        if(GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
    }

    private void ActivateItem()
    {
        drawerItem.SetActive(true);
    }
}
