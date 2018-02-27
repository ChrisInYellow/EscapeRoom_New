using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBoxTurner : MonoBehaviour
{
    private bool isRotating = false;
    private bool cooldown = false;
    public float rotateAngle = 36f;
    public float duration = .5f;
    private int LockNumber;

    public bool oneTrue;
    public bool twoTrue;
    public bool threeTrue;
    public bool fourTrue;

    public enum NumberOfCode {None,One,Two,Three,Four };
    public NumberOfCode numberOfCode = NumberOfCode.None;

	void FixedUpdate ()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.left, rotateAngle * Time.deltaTime * (1 / duration));
            Correction();
        }
    }

    public void StartRotation ()
    {
        if (!cooldown)
        {
            LockNumber++;
            cooldown = true;
            isRotating = true;
            Invoke("StopRotation", duration);
            if (LockNumber > 9)
            {
                LockNumber = 0;
            }
        }
    }

    public void StopRotation ()
    {
        cooldown = false;
        isRotating = false;
    }


    //passCode == 9 5 3 7
    public void Correction()
    {
        if (numberOfCode == NumberOfCode.One && LockNumber == 9)
            oneTrue = true;
        else
            oneTrue = false;

        if (numberOfCode == NumberOfCode.Two && LockNumber == 5)
            twoTrue = true;
        else
            twoTrue = false;

        if (numberOfCode == NumberOfCode.Three && LockNumber == 3)
            threeTrue = true;    
        else
            threeTrue = false;

        if (numberOfCode == NumberOfCode.Four && LockNumber == 7)
            fourTrue = true;
        else
            fourTrue = false;
    }
}
