using UnityEngine;

public class InteractivePainting : MonoBehaviour 
{
    private bool onePaintingIsCorrect = false;
    private bool twoPaintingsAreCorrect = false;

    private static InteractivePainting instance;
    public static InteractivePainting GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    Animator anim;
    void Start () 
	{
        anim = GetComponent<Animator>();
	}

    public void CheckNumberOfCorrectPositions (bool isCorrect, int numberOfPainting)
    {
        if (numberOfPainting == 1)
        {
            onePaintingIsCorrect = isCorrect;
        }
        if (numberOfPainting == 2)
        {
            twoPaintingsAreCorrect = isCorrect;
        }
        if (twoPaintingsAreCorrect && onePaintingIsCorrect)
        {
            AllPositionsAreCorrect();
        }
    }

    public void AllPositionsAreCorrect ()
    {
        anim.SetTrigger("OpenPainting");
    }
}
