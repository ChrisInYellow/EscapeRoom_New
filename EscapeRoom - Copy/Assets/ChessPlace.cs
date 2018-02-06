using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPlace : MonoBehaviour {

    public void SendInfo()
    {
        GetComponentInParent<ChessCorrectCombo>().Test(gameObject, transform.GetChild(1).gameObject);
    }

}
