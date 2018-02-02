﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Fader : MonoBehaviour {

    public Image fadeoutTexture;
    public float fadeSpeed;
    public LevelManager lvlmanager; 
    //private int drawdepth = 1000;
    public float alpha = 1.0f;
    //private int fadeDir = -1;

    private enum State { Idle, Fading };
    private State fadingState = State.Idle;

    // Use this for initialization
   public void Fade()
    {
        fadeoutTexture.color = new Color(0, 0, 0, 1f);

        fadingState = State.Fading; 

        if (fadingState == State.Fading)
        {
            StartCoroutine(FadeIn());
        }
    }

   public IEnumerator FadeIn()
    { 
        while(fadeoutTexture.color.a >= 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeoutTexture.color = new Color(0, 0, 0, alpha); 

            yield return null;
            fadingState = State.Idle; 
        }
        if(fadeoutTexture.color.a <= 0)
        {
            lvlmanager.LoadNewScene(); 
        }
    }
	// Update is called once per frame
}
