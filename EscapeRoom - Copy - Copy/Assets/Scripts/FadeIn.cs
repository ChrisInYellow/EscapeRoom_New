using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public static FadeIn Instance { set; get; }
    public Image fadeInImage;

    private bool inTransition;
    private bool isShowing;
    private float transition;
    public float duration;

    private void Awake()
    {
        Instance = this;
        Fading(true, 3f);

    }

    private void Update()
    {
        TransitionChecker();
        TransitionTime();
    }

    void TransitionChecker()
    {
        if (!inTransition)
        {
            return;
        }
    }

    void TransitionTime()
    {
        transition += (isShowing) ? -Time.deltaTime * (1 / duration) : Time.deltaTime * (1 / duration);

        fadeInImage.color = Color.Lerp(new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), transition);
        
        if(transition > 1 || transition < 0)
        {
            inTransition = false;
        }
    }

    public void Fading(bool showing, float duration)
    {
        isShowing = showing;
        inTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 1 : 0;
    }
}
