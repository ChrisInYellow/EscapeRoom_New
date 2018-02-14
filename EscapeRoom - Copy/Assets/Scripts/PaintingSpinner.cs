using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSpinner : MonoBehaviour {

    public GameObject[] paintings = new GameObject[2];
    public float correctRotationValue;
    bool isCurrentlyCorrect = false;
    int incorrectPaintingsRotated = 0;

	void Update () {
        PaintingsList();
	}

    void PaintingsList()
    {
        foreach (var art in paintings)
        {
            incorrectPaintingsRotated++;
        }

        //if(correctRotationValue == gameObject.tag.painting.rotation)
        //{
        //    incorrectPaintingsRotated--;
        //}

        if (incorrectPaintingsRotated == 0)
        {
            //gameObject.name.playanimation;
        }
    }

    void artSpinner()
    {
        //GameObject.
    }
}
