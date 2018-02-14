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
		if(codeNumber == CodeCorrect.One && gameObject.transform.rotation.x <= 50 && gameObject.transform.rotation.x >= 75)
        {
            spinnerOne = true;
        }
        if (codeNumber == CodeCorrect.Two && gameObject.transform.rotation.x <= 50 && gameObject.transform.rotation.x >= 75)
        {
            spinnerTwo = true;
        }
        if (codeNumber == CodeCorrect.Three && gameObject.transform.rotation.x <= 50 && gameObject.transform.rotation.x >= 75)
        {
            spinnerThree = true;
        }
        if (codeNumber == CodeCorrect.Four && gameObject.transform.rotation.x <= 50 && gameObject.transform.rotation.x >= 75)
        {
            spinnerFour = true;
        }
    }
}
