using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChessCorrectCombo : MonoBehaviour {

    //An event that will be called when the puzzle is solved.
    public UnityEvent complete = new UnityEvent(); 

    //Pieces placed and pieces needed to complete the puzzle.
    private int correctlyPlacedPieces = 0;
    private int solvedAmount = 4;

    //Adds to placedPieces when called.
    public void AddPiece()
    {
        correctlyPlacedPieces++;
        Solution();
    }

    //Removes from placedPieces when called.
    public void RemovePiece()
    {
        correctlyPlacedPieces--;
    }

    //Solves the puzzle when all pieces are placed correctly.
    private void Solution()
    {
        if (correctlyPlacedPieces == solvedAmount)
            PuzzleCleared();
    }

    //Calls upon complete event and plays a sound when the puzzle is solved.
    public void PuzzleCleared()
    {
        complete.Invoke();
        if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
    }
}