using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugPhysics : MonoBehaviour {

    public GameObject Liquid;
    public GameObject LiquidMesh;

    private int sloshSpeed = 60;
    private int rotateSpeed = 15;

    private int difference = 25; 

	
	// Update is called once per frame
	void Update () {
        Slosh();

        LiquidMesh.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self); 
	}

    private void Slosh()
    {
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);

        Vector3 FinalRotation = Quaternion.RotateTowards(Liquid.transform.localRotation, inverseRotation, sloshSpeed * Time.deltaTime).eulerAngles;

        FinalRotation.x = ClampRotationValue(FinalRotation.x, difference);
        FinalRotation.z = ClampRotationValue(FinalRotation.z, difference);

        Liquid.transform.localEulerAngles = FinalRotation; 
    }
    private float ClampRotationValue(float value, float difference)
    {
        float returnValue = 0.0f; 

        if(value> 100)
        {
            returnValue = Mathf.Clamp(value, 360 - difference, 360); 

        }
        else
        {
            returnValue = Mathf.Clamp(value, 0, difference); 
        }
        return returnValue; 
    }
}
