using UnityEngine;
using UnityEngine.Events;

public class CompletedPapperPuzzle : MonoBehaviour
{
    [SerializeField]
    public UnityEvent puzzleSolved = new UnityEvent();

    [HideInInspector]
    public float numberOfPlacedPappers = 0;

    public void IncreasePlacedPappers ()
    {
        //FindObjectOfType<AudioManager>().Play("PlacingPaper");
        numberOfPlacedPappers += 1;
        if (numberOfPlacedPappers == 5)
        {
            PuzzleSolved();
        }
    }

    public void PuzzleSolved()
    {
        puzzleSolved.Invoke();
        //FindObjectOfType<AudioManager>().Play("Hint");
    }
}
