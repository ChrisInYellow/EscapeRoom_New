using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{

    public Image fadeoutTexture;
    public float fadeSpeed;
    public LevelManager lvlmanager;
    public float alpha = 1.0f;

    public void FadeToBlack()
    {
        fadeoutTexture.color = new Color(0, 0, 0, 1f);

        StartCoroutine(FadeInBlack());
    }

    public IEnumerator FadeInBlack()
    {
        while (fadeoutTexture.color.a >= 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeoutTexture.color = new Color(0, 0, 0, alpha);

            yield return null;
        }
        FadeToNewScene();
    }

    public void FadeToWhite()
    {
        fadeoutTexture.color = new Color(255, 255, 255, 1f);

        StartCoroutine(FadeInWhite());
    }

    public IEnumerator FadeInWhite()
    {
        while (fadeoutTexture.color.a >= 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeoutTexture.color = new Color(255, 255, 255, alpha);

            yield return null;
        }
        FadeToNewScene();
    }

    public void FadeToNewScene()
    {
        if (fadeoutTexture.color.a <= 0)
        {
            lvlmanager.LoadNewScene();
        }
    }
}
