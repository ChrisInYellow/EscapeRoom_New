using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPuzzleSingleton : MonoBehaviour
{
    private static WallPuzzleSingleton instance;
    public static WallPuzzleSingleton GetInstance()
    {
        return instance;
    }

    private int numberOfCorrectTiles = 0;
    private int maxNumberOfTiles = 25;

    public void Awake()
    {
        instance = this;
    }

    public void CheckTiles (bool ifCorrectTile)
    {
        if (ifCorrectTile == true)
        {
            numberOfCorrectTiles += 1;
        }

        if (numberOfCorrectTiles == maxNumberOfTiles)
        {
            PuzzleDone();
        }
    }

    public void PuzzleDone ()
    {
        Debug.Log("Done!!");
    }
}
