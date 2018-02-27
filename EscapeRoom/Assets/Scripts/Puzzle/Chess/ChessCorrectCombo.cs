using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChessCorrectCombo : MonoBehaviour {

    public UnityEvent complete = new UnityEvent(); 

    private int clearAmount = 4;
    private int placedPieces = 0;

    void SolvedCombo()
    {
        if(placedPieces == clearAmount)
            PuzzleCleared();
    }

    public void AddPiece()
    {
        placedPieces++;
        SolvedCombo();
    }

    public void RemovePiece()
    {
        placedPieces--;
    }

    public void PuzzleCleared()
    {
        complete.Invoke();
        if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
    }
}