using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChessCorrectCombo : MonoBehaviour {

    public UnityEvent complete = new UnityEvent(); 
    public GameObject[] correctSpaces;
    public GameObject[] correctPawns;
    private bool[] cleared;

    void Start () {
        cleared = new bool[correctSpaces.Length];
	}

    void SolvedCombo()
    {
        int numberOfCorrect = 0;
        for (int i = 0; i < cleared.Length; i++)
        {
            if (cleared[i])
            {
                numberOfCorrect++;
            }
        }

        if (numberOfCorrect == correctSpaces.Length)
        {
            PuzzleCleared();
        }
    }

    public void CorrectPlacing(GameObject place, GameObject pawn)
    {
        for (int i = 0; i < cleared.Length; i++)
        {
            if(correctSpaces[i] == place)
            {
                if (correctPawns[i] == pawn)
                {
                    cleared[i] = true;
                    Debug.Log("Rätt");
                }
                else
                    cleared[i] = false;
            }
        }
            SolvedCombo();
    }

    public void InCorrectPlacing(GameObject place, GameObject pawn)
    {
        for (int i = 0; i < cleared.Length; i--)
        {
            if (correctSpaces[i] != place)
            {
                if (correctPawns[i] != pawn)
                {
                    cleared[i] = false;
                    Debug.Log("Fel/Saknas");
                }
                else
                    cleared[i] = false;
            }
        }
        SolvedCombo();
    }
    
    public void PuzzleCleared()
    {
        complete.Invoke();
        FindObjectOfType<AudioManager>().Play("Solution");
    }
}