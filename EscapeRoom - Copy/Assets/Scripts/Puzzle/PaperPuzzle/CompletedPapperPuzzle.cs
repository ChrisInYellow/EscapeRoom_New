using UnityEngine;
using UnityEngine.Events;

public class CompletedPapperPuzzle : MonoBehaviour
{
    AudioSource source;

    public AudioClip papperPlaced;
    public AudioClip pling;

    [SerializeField]
    public UnityEvent puzzleSolved = new UnityEvent();
    [HideInInspector]
    public float numberOfPlacedPappers = 0;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void IncreasePlacedPappers ()
    {
        if (source != null)
        {
            source.clip = papperPlaced;
            source.Play();
        }
        numberOfPlacedPappers += 1;
        if (numberOfPlacedPappers == 5)
        {
            PuzzleSolved();
        }
    }

    public void PuzzleSolved()
    {
        puzzleSolved.Invoke();
        if (source != null)
        {
            source.clip = pling;
            source.Play();
        }
    }
}
