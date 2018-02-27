using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MirrorRotation : MonoBehaviour
{
    public Vector3 amountOfDegrees;
    private Vector3 result;

    public void RealignLaserLeft()
    {
        result = Vector3.Scale(amountOfDegrees, Vector3.up);
        transform.Rotate(result);
    }

    public void RealignLaserRight()
    {
        result = Vector2.Scale(amountOfDegrees, Vector3.down);
        transform.Rotate(result);
    }
}
