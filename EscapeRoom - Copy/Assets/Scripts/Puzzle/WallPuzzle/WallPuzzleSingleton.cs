using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallPuzzleSingleton : MonoBehaviour
{
    public UnityEvent puzzleSolved = new UnityEvent();
    private static WallPuzzleSingleton instance;
    public static WallPuzzleSingleton GetInstance()
    {
        return instance;
    }

    private int numberOfCorrectTiles = 0;
    private int maxNumberOfTiles = 16;

    public void Awake()
    {
        instance = this;
    }

    public void CheckTiles ()
    {
        numberOfCorrectTiles += 1;
 
        if (numberOfCorrectTiles == maxNumberOfTiles)
        {
            PuzzleDone();
        }
    }

    public void PuzzleDone ()
    {
        print("Complete");
        puzzleSolved.Invoke();
    }
}
