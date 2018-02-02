using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessCorrectCombo : MonoBehaviour {

    public VRTK.VRTK_SnapDropZone correctSpace1;
    public VRTK.VRTK_SnapDropZone correctSpace2;
    public VRTK.VRTK_SnapDropZone correctSpace3;
    public VRTK.VRTK_SnapDropZone correctSpace4;
    public VRTK.VRTK_SnapDropZone correctSpace5;
    public VRTK.VRTK_SnapDropZone correctSpace6;
    public GameObject correctPawn1;
    public GameObject correctPawn2;
    public GameObject correctPawn3;
    public GameObject correctPawn4;
    public GameObject correctPawn5;
    public GameObject correctPawn6;

    void Start () {
       //TODO: investigate lisen to event?
        //correct1.ObjectSnappedToDropZone
	}
	

	void Update () {
        SolvedCombo();
    }

    void SolvedCombo()
    {
        if (correctSpace1.gameObject == correctPawn1 || correctSpace2.gameObject == correctPawn2 || correctSpace3.gameObject == correctPawn3 || correctSpace4.gameObject == correctPawn4 || correctSpace5.gameObject == correctPawn5 || correctSpace6.gameObject == correctPawn6)
        {
            Debug.Log("Rätt");
        }
        else if (correctSpace1.gameObject == correctPawn1 && correctSpace2.gameObject == correctPawn2 && correctSpace3.gameObject == correctPawn3 && correctSpace4.gameObject == correctPawn4 && correctSpace5.gameObject == correctPawn5 && correctSpace6.gameObject == correctPawn6)
        {
            Debug.Log("Win");
        }
    }
}