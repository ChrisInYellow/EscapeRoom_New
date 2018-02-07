using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPlace : MonoBehaviour {

    public void ChessCorrectPlus()
    {
        GetComponentInParent<ChessCorrectCombo>().CorrectPlacing(gameObject, transform.GetChild(1).gameObject);
    }

    public void ChessCorrectMinus()
    {
        GetComponentInParent<ChessCorrectCombo>().InCorrectPlacing(gameObject, transform.GetChild(1).gameObject);
    }
}
