﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBoxScript : MonoBehaviour {

    public enum CodeCorrect { Idle, One, Two, Three, Four };

    public CodeCorrect codeNumber = CodeCorrect.Idle;

    public bool spinnerOne;
    public bool spinnerTwo;
    public bool spinnerThree;
    public bool spinnerFour;

    //passCode == 9 5 3 7
	
	
	void Update () {
        Checking();
        Completed();
    }

    public void Checking()
    {
        if(gameObject.transform.rotation.x <= -450 || gameObject.transform.rotation.x >= 270)
        {
            gameObject.transform.rotation = new Quaternion (0,0.707f, 0,0.707f);
        }
		if(codeNumber == CodeCorrect.One && gameObject.transform.rotation.x <= 252 && gameObject.transform.rotation.x >= 216 || gameObject.transform.rotation.x <= -396 && gameObject.transform.rotation.x >= -432)
        {
            spinnerOne = true;
        }
        if (codeNumber == CodeCorrect.Two && gameObject.transform.rotation.x <= 108 && gameObject.transform.rotation.x >= 72 || gameObject.transform.rotation.x <= -252 && gameObject.transform.rotation.x >= -288)
        {
            spinnerTwo = true;
        }
        if (codeNumber == CodeCorrect.Three && gameObject.transform.rotation.x <= -180 && gameObject.transform.rotation.x >= -216 || gameObject.transform.rotation.x <= 36 && gameObject.transform.rotation.x >= 0)
        {
            spinnerThree = true;
        }
        if (codeNumber == CodeCorrect.Four && gameObject.transform.rotation.x <= -324 && gameObject.transform.rotation.x >= -360 || gameObject.transform.rotation.x <= 180 && gameObject.transform.rotation.x >= 144)
        {
            spinnerFour = true;
        }

    }
    public void Completed()
    {
        if(spinnerOne == true && spinnerTwo == true && spinnerThree == true && spinnerFour == true)
        {
            print("You did it!");
        }
    }
/*
0 = -90, 270, -450
1 = -126, -54
2 = -162, -18
3 = -198, 18
4 = -234, 54
5 = -270, 90
6 = -306, 126
7 = -342, 162
8 = -378, 198
9 = -414, 234 
*/
}
