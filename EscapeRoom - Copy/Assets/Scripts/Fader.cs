using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Fader : MonoBehaviour {

    public Image fadeoutTexture;
    public float fadeSpeed;
    public LevelManager lvlmanager; 
    public float alpha = 1.0f;


    // Use this for initialization
   public void Fade()
    {
        fadeoutTexture.color = new Color(0, 0, 0, 1f);

        StartCoroutine(FadeIn());
    }

    public void FadeToWhite()
    {
        fadeoutTexture.color = new Color(255, 255, 255, 1f);

            StartCoroutine(FadeFromWhite());
    }

    public IEnumerator FadeIn()
    { 
        while(fadeoutTexture.color.a >= 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeoutTexture.color = new Color(0, 0, 0, alpha);

            yield return null; 
        }
        if(fadeoutTexture.color.a <= 0)
        {
            lvlmanager.LoadNewScene(); 
        }
    }
	// Update is called once per frame

     public IEnumerator FadeFromWhite()
    {
        while (fadeoutTexture.color.a >=0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeoutTexture.color = new Color(255, 255, 255, alpha);

            yield return null;
        }
        if(fadeoutTexture.color.a <= 0)
        {
            lvlmanager.LoadNewScene(); 
        }
        
    }
}
