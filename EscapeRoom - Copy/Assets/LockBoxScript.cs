using System.Collections;
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
        if(gameObject.transform.rotation.x <= 450 || gameObject.transform.rotation.x >= 270)
        {
            gameObject.transform.rotation = new Quaternion (-0.707f,0,0,0.707f);
        }
		else if(codeNumber == CodeCorrect.One && gameObject.transform.rotation.x <= 252 && gameObject.transform.rotation.x >= 216 || gameObject.transform.rotation.x <= -396 && gameObject.transform.rotation.x >= -432)
        {
            spinnerOne = true;
        }
        else if (codeNumber == CodeCorrect.Two && gameObject.transform.rotation.x <= 108 && gameObject.transform.rotation.x >= 72 || gameObject.transform.rotation.x <= -252 && gameObject.transform.rotation.x >= -288)
        {
            spinnerTwo = true;
        }
        else if (codeNumber == CodeCorrect.Three && gameObject.transform.rotation.x <= -180 && gameObject.transform.rotation.x >= -216 || gameObject.transform.rotation.x <= 36 && gameObject.transform.rotation.x >= 0)
        {
            spinnerThree = true;
        }
        else if (codeNumber == CodeCorrect.Four && gameObject.transform.rotation.x <= -324 && gameObject.transform.rotation.x >= -360 || gameObject.transform.rotation.x <= 180 && gameObject.transform.rotation.x >= 144)
        {
            spinnerFour = true;
        }
    }
}
