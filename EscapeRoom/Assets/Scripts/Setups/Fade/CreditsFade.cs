﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

using UnityEngine.Video;
using VRTK;

public class CreditsFade : MonoBehaviour
{
    public VRTK_HeadsetFade fade;
    public Camera creditsCam;
    public float dur;
    private VideoPlayer video;

    private void Start()
    {
        video = GetComponentInChildren<VideoPlayer>();

    }
    private void OnTriggerEnter(Collider other)
    {
        ActivateCredits();
    }

    public void ActivateCredits()
    {
        fade.Fade(new Color(0, 0, 0), dur);
        StartCoroutine(CreditSpwan());
    }

    private IEnumerator CreditSpwan()

    {
        yield return new WaitForSeconds(dur);
        creditsCam.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        fade.gameObject.SetActive(false);
        creditsCam.GetComponent<Camera>().enabled = true;
        StartCoroutine(MenuLoader());
    }
    private IEnumerator MenuLoader()
    {
        yield return new WaitForSeconds(48f);
        SceneManager.LoadScene("MainMenu");
    }
}
