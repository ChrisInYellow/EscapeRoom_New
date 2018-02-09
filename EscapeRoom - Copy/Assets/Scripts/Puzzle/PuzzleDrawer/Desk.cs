using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour {

    private Animator anim;
    private GameObject battery;

    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        battery = transform.GetChild(0).GetChild(0).gameObject;
    }

    public void Open()
    {
        anim.SetBool("Open", true);
        StartCoroutine(SpawnItem(0.5f));
        FindObjectOfType<AudioManager>().Play("DrawerOpen");
    }

    private IEnumerator SpawnItem(float time)
    {
        yield return new WaitForSeconds(time);
        battery.SetActive(true);
    }
}
