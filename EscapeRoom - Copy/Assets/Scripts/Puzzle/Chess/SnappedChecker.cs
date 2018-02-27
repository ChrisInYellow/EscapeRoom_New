using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappedChecker : MonoBehaviour {

    //Makes a list of the chess pieces that can snap to the chess board.
    public GameObject[] snappablePawns = new GameObject[6];
    //Keeps track if a piece is snapped to the chess board and if it is placed correctly.
    private bool isSnapped = false;
    public bool correctSnapped;
}
