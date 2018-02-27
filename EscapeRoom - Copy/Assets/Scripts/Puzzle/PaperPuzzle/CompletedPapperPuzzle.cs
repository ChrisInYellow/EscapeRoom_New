using UnityEngine;
using UnityEngine.Events;

public class CompletedPapperPuzzle : MonoBehaviour
{
    [SerializeField]
    public UnityEvent puzzleSolved = new UnityEvent();
    public AudioClip solveSound;
    [HideInInspector]
    public float numberOfPlacedPappers = 0;

    public void IncreasePlacedPappers ()
    {
        if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
        numberOfPlacedPappers += 1;
        if (numberOfPlacedPappers == 5)
        {
            PuzzleSolved();
        }
    }

    public void PuzzleSolved()
    {
        puzzleSolved.Invoke();
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().clip = solveSound;
            GetComponent<AudioSource>().Play();
        }
    }
}
