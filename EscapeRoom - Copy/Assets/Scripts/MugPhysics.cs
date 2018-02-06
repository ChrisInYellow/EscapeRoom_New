using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugPhysics : MonoBehaviour {

    public GameObject Liquid;
    public GameObject LiquidMesh; 

    private int sloshSpeed = 60;
    private int rotateSpeed = 15;

    private int difference = 25; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Slosh();

        LiquidMesh.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self); 
		
	}

    private void Slosh()
    {
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);

        Vector3 finalRotation = Quaternion.RotateTowards(Liquid.transform.localRotation, inverseRotation, sloshSpeed * Time.deltaTime).eulerAngles;

        finalRotation.x = ClampRotationValue(finalRotation.x, difference);
        finalRotation.z = ClampRotationValue(finalRotation.z, difference);

        Liquid.transform.localEulerAngles = finalRotation; 
    }

    private float ClampRotationValue(float value, float difference)
    {
        float returnValue = 0.0f; 

        if(value > 100)
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
