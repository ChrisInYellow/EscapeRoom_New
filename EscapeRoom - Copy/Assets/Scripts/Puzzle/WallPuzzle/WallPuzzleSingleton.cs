using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallPuzzleSingleton : MonoBehaviour
{
    private List<GameObject> correctTileObjects = new List<GameObject>();

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

    public void CheckTiles (GameObject tile, bool correct)
    {
        bool newObject = true;
        for (int i = 0; i < correctTileObjects.Count; i++)
        {
            if (correctTileObjects[i] == tile)
            {
                newObject = false;
            }
        }
        if (newObject)
        {
            correctTileObjects.Add(tile);
        }

        numberOfCorrectTiles = 0;

        for (int i = 0; i < correctTileObjects.Count; i++)
        {
            if (correctTileObjects[i].GetComponent<TileWall>().isRight)
            {
                numberOfCorrectTiles += 1;
            }
        }

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
