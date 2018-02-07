using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessCorrectCombo : MonoBehaviour {

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

        Debug.Log("" + numberOfCorrect);

        if (numberOfCorrect == correctSpaces.Length)
        {
            Debug.Log("Win");
        }
    }

    public void Test(GameObject place, GameObject pawn)
    {
        print("got here");
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
}