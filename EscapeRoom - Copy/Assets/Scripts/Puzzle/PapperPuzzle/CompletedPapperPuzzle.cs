using System.Collections;
using System.Collections.Generic;
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
        numberOfPlacedPappers += 1;
        if (numberOfPlacedPappers == 5)
        {
            PuzzleSolved();
        }
    }

    public void PuzzleSolved()
    {
        puzzleSolved.Invoke();
        FindObjectOfType<AudioManager>().Play("Solution");
        FindObjectOfType<AudioManager>().Play("Hint");
    }
}
